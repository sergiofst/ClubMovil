Namespace Controls
    Public Class RecursiveULMenu
        Inherits HierarchicalDataBoundControl

        ' Template Declarations
        Private _HeaderTemplate As ITemplate
        Private _FooterTemplate As ITemplate
        Private _ItemTemplate As ITemplate
        Private _ItemHeaderTemplate As ITemplate
        Private _ItemFooterTemplate As ITemplate

        <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(LIDataItem))> _
        Public Property HeaderTemplate() As ITemplate
            Get
                Return _HeaderTemplate
            End Get
            Set(ByVal value As ITemplate)
                _HeaderTemplate = value
            End Set
        End Property

        <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(LIDataItem))> _
        Public Property FooterTemplate() As ITemplate
            Get
                Return _FooterTemplate
            End Get
            Set(ByVal value As ITemplate)
                _FooterTemplate = value
            End Set
        End Property

        <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(LIDataItem))> _
        Public Property ItemTemplate() As ITemplate
            Get
                Return _ItemTemplate
            End Get
            Set(ByVal value As ITemplate)
                _ItemTemplate = value
            End Set
        End Property

        <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(LIDataItem))> _
        Public Property ItemHeaderTemplate() As ITemplate
            Get
                Return _ItemHeaderTemplate
            End Get
            Set(ByVal value As ITemplate)
                _ItemHeaderTemplate = value
            End Set
        End Property

        <PersistenceMode(PersistenceMode.InnerProperty), TemplateContainer(GetType(LIDataItem))> _
        Public Property ItemFooterTemplate() As ITemplate
            Get
                Return _ItemFooterTemplate
            End Get
            Set(ByVal value As ITemplate)
                _ItemFooterTemplate = value
            End Set
        End Property

        ' Field to find the data value from
        Public Property TextField() As String
            Get
                Dim o As Object = ViewState("TextField")
                If o Is Nothing Then
                    Return String.Empty
                Else
                    Return CType(o, String)
                End If
            End Get
            Set(ByVal value As String)
                ViewState("TextField") = value
            End Set
        End Property

        Protected Overrides Sub CreateChildControls()
            RecursiveCreateChildControls(GetData("").Select())
        End Sub

        Private Sub RecursiveCreateChildControls(ByVal dataItems As IHierarchicalEnumerable)
            Dim firstItem As Boolean = True
            For Each e As Object In dataItems

                ' Render the header only if we have child items
                If firstItem Then
                    Dim header As New LIDataItem(String.Empty)
                    HeaderTemplate.InstantiateIn(header)
                    Controls.Add(header)
                    firstItem = False
                End If

                Dim data As IHierarchyData = dataItems.GetHierarchyData(e)

                ' Find the data value based on the TextField
                Dim text As String = String.Empty
                text = CStr(DataBinder.GetPropertyValue(data, TextField))

                ' Create an item header
                Dim itemHeader As New LIDataItem(String.Empty)
                ItemHeaderTemplate.InstantiateIn(itemHeader)
                Controls.Add(itemHeader)
                itemHeader.DataBind()

                ' Create the data item
                Dim item As New LIDataItem(text)
                ItemTemplate.InstantiateIn(item)
                Controls.Add(item)
                item.DataBind()

                ' Create any child items
                RecursiveCreateChildControls(data.GetChildren())

                ' Create the item footer
                Dim itemFooter As New LIDataItem(String.Empty)
                ItemFooterTemplate.InstantiateIn(itemFooter)
                Controls.Add(itemFooter)
                itemFooter.DataBind()

            Next

            ' If we had a header, then render out the footer
            If firstItem = False Then
                Dim footer As New LIDataItem(String.Empty)
                FooterTemplate.InstantiateIn(footer)
                Controls.Add(footer)
            End If
        End Sub

    End Class


    Public Class LIDataItem
        Inherits Control
        Implements INamingContainer
        Implements IDataItemContainer

        ' The item data
        Private _text As String
        Public ReadOnly Property Text() As String
            Get
                Return _text
            End Get
        End Property

        Public Sub New(ByVal Text As String)
            _text = Text
        End Sub

        Public ReadOnly Property DataItem() As Object Implements System.Web.UI.IDataItemContainer.DataItem
            Get
                Return Me
            End Get
        End Property

        Public ReadOnly Property DataItemIndex() As Integer Implements System.Web.UI.IDataItemContainer.DataItemIndex
            Get
                Return 0
            End Get
        End Property

        Public ReadOnly Property DisplayIndex() As Integer Implements System.Web.UI.IDataItemContainer.DisplayIndex
            Get
                Return 0
            End Get
        End Property
    End Class
End Namespace
