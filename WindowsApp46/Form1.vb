Imports System.Net.Http
Imports System.IO
Imports Newtonsoft.Json.Linq
Imports System.Linq

Public Class Form1
    Private authToken As String = "82ad97f02478cd70441e099c53b0ac9652a5586b9e23f52beeae7a34cfe6e81a" ' ضع رمز التحقق هناYour API Token

    Private Async Sub btnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        TextBox1.Clear()
        txtResult.Clear()
        Await Task.Delay(1000)
        Dim filePath As String = Label1.Text

        If File.Exists(filePath) Then
            Dim result As JObject = Await InitiateScan("https://kleenscan.com/api/v1/file/scan", authToken, filePath)
            If result IsNot Nothing AndAlso result("success").Value(Of Boolean)() Then
                Dim scanToken As String = result("data")("scan_token").ToString()
                txtResult.Text = "Scan initiated. Token: " & scanToken
                Await GetScanResults(scanToken, authToken)
            Else
                txtResult.Text = "Error: " & result("message").ToString()
            End If
        Else
            MessageBox.Show("Please select a valid file.")
        End If
    End Sub

    Private Async Function InitiateScan(url As String, authToken As String, path As String, Optional avList As String = "all") As Task(Of JObject)
        Using client As New HttpClient()
            Using content As New MultipartFormDataContent()
                content.Add(New StreamContent(File.OpenRead(path)), "path", IO.Path.GetFileName(path))
                content.Add(New StringContent(avList), "avList")

                client.DefaultRequestHeaders.Add("X-Auth-Token", authToken)
                Dim response As HttpResponseMessage = Await client.PostAsync(url, content)
                Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
                Return JObject.Parse(jsonResponse)
            End Using
        End Using
    End Function
    Private Async Function GetScanResults(scanToken As String, authToken As String) As Task
        Dim url As String = "https://kleenscan.com/api/v1/file/result/" & scanToken

        Using client As New HttpClient()
            client.DefaultRequestHeaders.Add("X-Auth-Token", authToken)

            For i As Integer = 1 To 6
                Dim response As HttpResponseMessage = Await client.GetAsync(url)
                Dim jsonResponse As String = Await response.Content.ReadAsStringAsync()
                Dim result As JObject = JObject.Parse(jsonResponse)

                If result("success").Value(Of Boolean)() Then
                    Dim data As JArray = DirectCast(result("data"), JArray)
                    Dim scannedCount As Integer = data.Where(Function(s) s("status").ToString() = "ok").Count

                    If scannedCount = data.Count Then
                        txtResult.Text = "All scanners have finished: " & data.ToString()

                        Exit For
                    Else
                        txtResult.Text = "Some scanners are still working (" & scannedCount & "/" & data.Count & ") done, sleeping for 1 minute .."
                        Label2.Text = "Scann Startet......"
                        Await Task.Delay(60000) ' انتظر لمدة دقيقة واحدة
                        ' عرض رابط الفحص بمجرد الانتهاء من الفحص
                        Label2.Text = "Done"
                        Dim scanLink As String = "https://kleenscan.com/scan_result/" & scanToken
                        TextBox1.Text = (scanLink)
                        Process.Start(scanLink)
                    End If
                Else
                    txtResult.Text = "Error: " & result("message").ToString()
                    Exit For
                End If
            Next
        End Using
    End Function


    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using ofd As New OpenFileDialog()
            If ofd.ShowDialog() = DialogResult.OK Then
                Label1.Text = ofd.FileName
            End If
        End Using
    End Sub
End Class
