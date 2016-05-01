Imports System.ComponentModel.DataAnnotations
Imports Microsoft.AspNet.Identity
Imports Microsoft.Owin.Security
Imports System.Globalization

Public Class Visitor
    Public Property VisitorId As Int16
    Public Property Name As String
    Public Property VisitingPerson As String
    Public Property Signin As DateTime
    Public Property Signout As DateTime
End Class
