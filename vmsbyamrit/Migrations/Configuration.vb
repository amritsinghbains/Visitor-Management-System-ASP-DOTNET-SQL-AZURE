Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq
Imports vmsbyamrit.Visitor


Namespace Migrations

    Friend NotInheritable Class Configuration 
        Inherits DbMigrationsConfiguration(Of ApplicationDbContext)

        Public Sub New()
            AutomaticMigrationsEnabled = False
        End Sub

        Protected Overrides Sub Seed(context As ApplicationDbContext)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method 
            '  to avoid creating duplicate seed data. E.g.
            '
            context.Visitors.AddOrUpdate(
                Function(c) c.VisitorId,
                           New Visitor() With {.VisitorId = 1,
                .Name = "david",
                .VisitingPerson = "sean",
                .Signin = "2015-11-11 11:00",
                .Signout = "2015-11-11 12:00"},
                           New Visitor() With {.VisitorId = 2,
                .Name = "michelle",
                .VisitingPerson = "sean",
                .Signin = "2015-11-11 11:30",
                .Signout = "2015-11-11 12:30"})
        End Sub

    End Class

End Namespace
