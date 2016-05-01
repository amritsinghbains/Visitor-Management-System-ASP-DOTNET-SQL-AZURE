Imports System.Data.Entity
Imports System.Security.Claims
Imports System.Threading.Tasks
Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity.Owin

' You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
Public Class ApplicationUser
    Inherits IdentityUser
    Public Async Function GenerateUserIdentityAsync(manager As UserManager(Of ApplicationUser)) As Task(Of ClaimsIdentity)
        ' Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        Dim userIdentity = Await manager.CreateIdentityAsync(Me, DefaultAuthenticationTypes.ApplicationCookie)
        ' Add custom user claims here
        Return userIdentity
    End Function
End Class

Public Class ApplicationDbContext
    Inherits IdentityDbContext(Of ApplicationUser)
    Public Sub New()
        MyBase.New("DefaultConnection", throwIfV1Schema:=False)
    End Sub

    Public Shared Function Create() As ApplicationDbContext
        Return New ApplicationDbContext()
    End Function

    Public Property Visitors As System.Data.Entity.DbSet(Of Visitor)
End Class

Public Class EFContext
    Inherits DbContext
    Public Sub New()
        MyBase.New(ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString)
    End Sub
    Private _systemVisitor As DbSet(Of Visitor)
    Public Property SystemUsers() As DbSet(Of Visitor)
        Get
            Return _systemVisitor
        End Get
        Set(value As DbSet(Of Visitor))
            _systemVisitor = value
        End Set
    End Property
    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
        Database.SetInitializer(Of EFContext)(Nothing)
    End Sub

End Class