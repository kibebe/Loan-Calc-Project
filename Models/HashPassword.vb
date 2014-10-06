Imports System.Security.Cryptography
Imports System.Text
Public Class HashPassword
    Public Function GetPasswordHash(ByVal message As String) As String
        Dim enc As System.Text.Encoding = New System.Text.ASCIIEncoding
        'Let us use SHA256 algorithm to 
        ' generate the hash from this  password
        Dim sha As SHA256 = New SHA256CryptoServiceProvider()
        Dim dataBytes As Byte() = enc.GetBytes(message)
        Dim resultBytes As Byte() = sha.ComputeHash(dataBytes)

        ' return the hash string to the caller
        Return enc.GetString(resultBytes)
    End Function
End Class
