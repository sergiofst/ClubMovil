Imports System.Data
Imports System.Collections
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls

Namespace Adapters
    Public Class RUGridViewAdapter
        Inherits System.Web.UI.WebControls.Adapters.WebControlAdapter


        Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
            Dim gridView As GridView = TryCast(Control, GridView)
            If gridView IsNot Nothing Then
                writer.Indent += 1
                WritePagerSection(writer, PagerPosition.Top)

                writer.WriteLine()
                writer.WriteBeginTag("table")
                writer.WriteAttribute("cellpadding", "0")
                writer.WriteAttribute("cellspacing", "0")
                writer.WriteAttribute("summary", Control.ToolTip)

                If Not [String].IsNullOrEmpty(gridView.CssClass) Then
                    writer.WriteAttribute("class", gridView.CssClass)
                End If

                writer.Write(HtmlTextWriter.TagRightChar)
                writer.Indent += 1

                Dim rows As New ArrayList()
                Dim gvrc As GridViewRowCollection = Nothing

                ' ////////////////// HEAD /////////////////////////////

                rows.Clear()
                If gridView.ShowHeader AndAlso (gridView.HeaderRow IsNot Nothing) Then
                    rows.Add(gridView.HeaderRow)
                End If
                gvrc = New GridViewRowCollection(rows)
                WriteRows(writer, gridView, gvrc, "thead")

                ' ////////////////// FOOT /////////////////////////////

                rows.Clear()
                If gridView.ShowFooter AndAlso (gridView.FooterRow IsNot Nothing) Then
                    rows.Add(gridView.FooterRow)
                End If
                gvrc = New GridViewRowCollection(rows)
                WriteRows(writer, gridView, gvrc, "tfoot")

                ' ////////////////// BODY /////////////////////////////

                WriteRows(writer, gridView, gridView.Rows, "tbody")

                ' /////////////////////////////////////////////////////

                writer.Indent -= 1
                writer.WriteLine()
                writer.WriteEndTag("table")

                WritePagerSection(writer, PagerPosition.Bottom)

                writer.Indent -= 1
                writer.WriteLine()
            End If
        End Sub

        ''' ///////////////////////////////////////////////////////////////////////////////
        ''' PRIVATE        

        Private Sub RegisterScripts()
        End Sub

        Private Sub WriteRows(ByVal writer As HtmlTextWriter, ByVal gridView As GridView, ByVal rows As GridViewRowCollection, ByVal tableSection As String)
            If rows.Count > 0 Then
                writer.WriteLine()
                writer.WriteBeginTag(tableSection)
                writer.Write(HtmlTextWriter.TagRightChar)
                writer.Indent += 1

                For Each row As GridViewRow In rows
                    writer.WriteLine()
                    writer.WriteBeginTag("tr")


                    ' Attributos
                    For Each key As String In row.Attributes.Keys
                        writer.WriteAttribute(key, row.Attributes(key))
                    Next

                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Indent += 1

                    For Each cell As TableCell In row.Cells
                        Dim fieldCell As DataControlFieldCell = TryCast(cell, DataControlFieldCell)
                        If (fieldCell IsNot Nothing) AndAlso (fieldCell.ContainingField IsNot Nothing) Then
                            Dim field As DataControlField = fieldCell.ContainingField
                            cell.ApplyStyle(field.ItemStyle)
                            If Not field.Visible Then
                                cell.Visible = False
                            End If
                        End If

                        writer.WriteLine()
                        cell.RenderControl(writer)
                    Next

                    writer.Indent -= 1
                    writer.WriteLine()
                    writer.WriteEndTag("tr")
                Next

                writer.Indent -= 1
                writer.WriteLine()
                writer.WriteEndTag(tableSection)
            End If
        End Sub

        Private Sub WritePagerSection(ByVal writer As HtmlTextWriter, ByVal pos As PagerPosition)
            Dim gridView As GridView = TryCast(Control, GridView)
            If (gridView IsNot Nothing) AndAlso gridView.AllowPaging AndAlso ((gridView.PagerSettings.Position = pos) OrElse (gridView.PagerSettings.Position = PagerPosition.TopAndBottom)) Then
                Dim innerTable As Table = Nothing
                If (pos = PagerPosition.Top) AndAlso (gridView.TopPagerRow IsNot Nothing) AndAlso (gridView.TopPagerRow.Cells.Count = 1) AndAlso (gridView.TopPagerRow.Cells(0).Controls.Count = 1) AndAlso GetType(Table).IsAssignableFrom(gridView.TopPagerRow.Cells(0).Controls(0).[GetType]()) Then
                    innerTable = TryCast(gridView.TopPagerRow.Cells(0).Controls(0), Table)
                ElseIf (pos = PagerPosition.Bottom) AndAlso (gridView.BottomPagerRow IsNot Nothing) AndAlso (gridView.BottomPagerRow.Cells.Count = 1) AndAlso (gridView.BottomPagerRow.Cells(0).Controls.Count = 1) AndAlso GetType(Table).IsAssignableFrom(gridView.BottomPagerRow.Cells(0).Controls(0).[GetType]()) Then
                    innerTable = TryCast(gridView.BottomPagerRow.Cells(0).Controls(0), Table)
                End If

                If (innerTable IsNot Nothing) AndAlso (innerTable.Rows.Count = 1) Then
                    writer.WriteLine()
                    writer.WriteBeginTag("div")
                    writer.Write(HtmlTextWriter.TagRightChar)
                    writer.Indent += 1

                    Dim row As TableRow = innerTable.Rows(0)
                    For Each cell As TableCell In row.Cells
                        For Each ctrl As Control In cell.Controls
                            writer.WriteLine()
                            ctrl.RenderControl(writer)
                        Next
                    Next

                    writer.Indent -= 1
                    writer.WriteLine()
                    writer.WriteEndTag("div")
                End If
            End If
        End Sub
    End Class
End Namespace
