Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Module Module1

    <DllImport("User32.dll")>
    Private Function FindWindow(lpClassName As String, lpWindowName As String) As IntPtr

    End Function

    <DllImport("User32.dll")>
    Private Function SetForegroundWindow(hWnd As IntPtr) As Boolean

    End Function

    Sub Main()

        For Each item In IO.Directory.GetFiles(My.Settings.AppFilePath, "*.lnk")
            Debug.WriteLine(item)

            ' 启动失败
            If Wangk.ResourceWPF.FileHelper.Open(item) <> 42 Then

                Process.Start(item)

            End If

        Next

        ' 点击微信登录按钮
        Do
            Dim WeChatLoginWndHandle = FindWindow("WeChatLoginWndForPC", Nothing)
            If WeChatLoginWndHandle = 0 Then
                Threading.Thread.Sleep(1000)
                Continue Do
            End If

            SetForegroundWindow(WeChatLoginWndHandle)
            SendKeys.SendWait("{ENTER}")

            Exit Do
        Loop


    End Sub

End Module
