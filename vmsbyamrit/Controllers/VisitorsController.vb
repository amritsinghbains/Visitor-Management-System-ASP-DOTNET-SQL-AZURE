Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Data.Entity.Core.Objects
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports vmsbyamrit

Namespace Controllers
    Public Class VisitorsController
        Inherits System.Web.Mvc.Controller

        Private db As New ApplicationDbContext

        Function Index(ByVal searchString As String, ByVal durationString1 As Short?, ByVal durationString2 As Short?, ByVal signedStatusString As String) As ActionResult
            Dim visitors = From m In db.Visitors Select m
            Dim currentDateTime = DateTime.Now
            If Not String.IsNullOrEmpty(searchString) Then
                visitors = visitors.Where(Function(visitor) visitor.VisitingPerson.Contains(searchString))
            End If

            If Not IsNothing(durationString1) Then
                visitors = visitors.Where(Function(visitor) System.Data.Entity.DbFunctions.DiffMinutes(visitor.Signin, visitor.Signout) >= durationString1 And System.Data.Entity.DbFunctions.DiffMinutes(visitor.Signin, visitor.Signout) <= durationString2)
            End If

            If Not String.IsNullOrEmpty(signedStatusString) Then
                If (signedStatusString).Equals("present") Then
                    System.Diagnostics.Debug.WriteLine("present")
                    visitors = visitors.Where(Function(visitor) System.Data.Entity.DbFunctions.DiffSeconds(DateTime.Now, visitor.Signout) > 0 And System.Data.Entity.DbFunctions.DiffSeconds(visitor.Signin, DateTime.Now) > 0)

                ElseIf (signedStatusString).Equals("absent") Then
                    System.Diagnostics.Debug.WriteLine("absent")
                    visitors = visitors.Where(Function(visitor) System.Data.Entity.DbFunctions.DiffSeconds(DateTime.Now, visitor.Signout) < 0 Or System.Data.Entity.DbFunctions.DiffSeconds(visitor.Signin, DateTime.Now) < 0)
                End If
            End If

            Return View(visitors)
        End Function

        Function Index2() As ActionResult
            Return View(db.Visitors.ToList())
        End Function

        ' GET: Visitors/Details/5
        Function Details(ByVal id As Short?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim visitor As Visitor = db.Visitors.Find(id)
            If IsNothing(visitor) Then
                Return HttpNotFound()
            End If
            Return View(visitor)
        End Function

        ' GET: Visitors/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Visitors/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="VisitorId,Name,VisitingPerson,Signin,Signout")> ByVal visitor As Visitor) As ActionResult
            If ModelState.IsValid Then
                db.Visitors.Add(visitor)
                db.SaveChanges()
                If Request.IsAuthenticated Then
                    Return RedirectToAction("Index")
                Else
                    Return RedirectToAction("Create")
                End If
            End If
            Return View(visitor)
        End Function

        ' GET: Visitors/Edit/5
        Function Edit(ByVal id As Short?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim visitor As Visitor = db.Visitors.Find(id)
            If IsNothing(visitor) Then
                Return HttpNotFound()
            End If
            Return View(visitor)
        End Function

        ' POST: Visitors/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="VisitorId,Name,VisitingPerson,Signin,Signout")> ByVal visitor As Visitor) As ActionResult
            If ModelState.IsValid Then
                db.Entry(visitor).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(visitor)
        End Function

        ' GET: Visitors/Delete/5
        Function Delete(ByVal id As Short?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim visitor As Visitor = db.Visitors.Find(id)
            If IsNothing(visitor) Then
                Return HttpNotFound()
            End If
            Return View(visitor)
        End Function

        ' POST: Visitors/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Short) As ActionResult
            Dim visitor As Visitor = db.Visitors.Find(id)
            db.Visitors.Remove(visitor)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
