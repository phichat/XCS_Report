Namespace XCS_Report.Models
    Public Class ILL_P030

        Public Class ArrestgetByConmodel
            Private _ArrestCode As String
            Public Property ArrestCode() As String
                Get
                    Return _ArrestCode
                End Get
                Set(ByVal value As String)
                    _ArrestCode = value
                End Set
            End Property
        End Class

        Public Class ArrestgetByCon
            Private _ArrestCode As String
            Public Property ArrestCode() As String
                Get
                    Return _ArrestCode
                End Get
                Set(ByVal value As String)
                    _ArrestCode = value
                End Set
            End Property

            Private _ArrestStation As String
            Public Property ArrestStation() As String
                Get
                    Return _ArrestStation
                End Get
                Set(ByVal value As String)
                    _ArrestStation = value
                End Set
            End Property

            Private _ArrestDate As DateTime
            Public Property ArrestDate() As DateTime
                Get
                    Return _ArrestDate
                End Get
                Set(ByVal value As DateTime)
                    _ArrestDate = value
                End Set
            End Property

            Private _ArrestTime As String
            Public Property ArrestTime() As String
                Get
                    Return _ArrestTime
                End Get
                Set(ByVal value As String)
                    _ArrestTime = value
                End Set
            End Property

            Private _OccurrenceDate As DateTime
            Public Property OccurrenceDate() As DateTime
                Get
                    Return _OccurrenceDate
                End Get
                Set(ByVal value As DateTime)
                    _OccurrenceDate = value
                End Set
            End Property

            Private _OccurrenceTime As String
            Public Property OccurrenceTime() As String
                Get
                    Return _OccurrenceTime
                End Get
                Set(ByVal value As String)
                    _OccurrenceTime = value
                End Set
            End Property

            Private _Behaviour As String
            Public Property Behaviour() As String
                Get
                    Return _Behaviour
                End Get
                Set(ByVal value As String)
                    _Behaviour = value
                End Set
            End Property

            Private _Prompt As String
            Public Property Prompt() As String
                Get
                    Return _Prompt
                End Get
                Set(ByVal value As String)
                    _Prompt = value
                End Set
            End Property

            Private _ArrestLocale As List(Of ArrestLocale)
            Public Property ArrestLocale() As List(Of ArrestLocale)
                Get
                    Return _ArrestLocale
                End Get
                Set(ByVal value As List(Of ArrestLocale))
                    _ArrestLocale = value
                End Set
            End Property

            Private _ArrestStaff As List(Of ArrestStaff)
            Public Property ArrestStaff() As List(Of ArrestStaff)
                Get
                    Return _ArrestStaff
                End Get
                Set(ByVal value As List(Of ArrestStaff))
                    _ArrestStaff = value
                End Set
            End Property

            Private _ArrestProduct As List(Of ArrestProduct)
            Public Property ArrestProduct() As List(Of ArrestProduct)
                Get
                Return _ ArrestProduct
                End Get
                Set(ByVal value As List(Of ArrestProduct))
                    _ArrestProduct = value
                End Set
            End Property

            Private _ArrestIndictment As List(Of ArrestIndictment)
            Public Property ArrestIndictment() As List(Of ArrestIndictment)
                Get
                    Return _ArrestIndictment
                End Get
                Set(ByVal value As List(Of ArrestIndictment))
                    _ArrestIndictment = value
                End Set
            End Property
        End Class

        Public Class ArrestLocale
            Private _Location As String
            Public Property Location() As String
                Get
                    Return _Location
                End Get
                Set(ByVal value As String)
                    _Location = value
                End Set
            End Property

            Private _Address As String
            Public Property Address() As String
                Get
                    Return _Address
                End Get
                Set(ByVal value As String)
                    _Address = value
                End Set
            End Property

            Private _Village As String
            Public Property Village() As String
                Get
                    Return _Village
                End Get
                Set(ByVal value As String)
                    _Village = value
                End Set
            End Property

            Private _Building As String
            Public Property Building() As String
                Get
                    Return _Building
                End Get
                Set(ByVal value As String)
                    _Building = value
                End Set
            End Property

            Private _Floor As String
            Public Property Floor() As String
                Get
                    Return _Floor
                End Get
                Set(ByVal value As String)
                    _Floor = value
                End Set
            End Property

            Private _Room As String
            Public Property Room() As String
                Get
                    Return _Room
                End Get
                Set(ByVal value As String)
                    _Room = value
                End Set
            End Property

            Private _Alley As String
            Public Property Alley() As String
                Get
                    Return _Alley
                End Get
                Set(ByVal value As String)
                    _Alley = value
                End Set
            End Property

            Private _Road As String
            Public Property Road() As String
                Get
                    Return _Road
                End Get
                Set(ByVal value As String)
                    _Road = value
                End Set
            End Property

            Private _SubDistrict As String
            Public Property SubDistrict() As String
                Get
                    Return _SubDistrict
                End Get
                Set(ByVal value As String)
                    _SubDistrict = value
                End Set
            End Property

            Private _District As String
            Public Property District() As String
                Get
                    Return _District
                End Get
                Set(ByVal value As String)
                    _District = value
                End Set
            End Property

            Private _Province As String
            Public Property Province() As String
                Get
                    Return _Province
                End Get
                Set(ByVal value As String)
                    _Province = value
                End Set
            End Property
        End Class

        Public Class ArrestStaff
            Private _TitleName As String
            Public Property TitleName() As String
                Get
                    Return _TitleName
                End Get
                Set(ByVal value As String)
                    _TitleName = value
                End Set
            End Property

            Private _FirstName As String
            Public Property FirstName() As String
                Get
                    Return _FirstName
                End Get
                Set(ByVal value As String)
                    _FirstName = value
                End Set
            End Property

            Private _LastName As String
            Public Property LastName() As String
                Get
                    Return _LastName
                End Get
                Set(ByVal value As String)
                    _LastName = value
                End Set
            End Property

            Private _PositionName As String
            Public Property PositionName() As String
                Get
                    Return _PositionName
                End Get
                Set(ByVal value As String)
                    _PositionName = value
                End Set
            End Property

            Private _OfficeName As String
            Public Property OfficeName() As String
                Get
                    Return _OfficeName
                End Get
                Set(ByVal value As String)
                    _PositionName = value
                End Set
            End Property

            Private _ContributorCode As Integer
            Public Property ContributorCode() As String
                Get
                    Return _ContributorCode
                End Get
                Set(ByVal value As String)
                    _ContributorCode = value
                End Set
            End Property
        End Class

        Public Class ArrestProduct
            Private _ProductDesc As String
            Public Property ProductDesc() As String
                Get
                    Return _ProductDesc
                End Get
                Set(ByVal value As String)
                    _ProductDesc = value
                End Set
            End Property

            Private _Qty As String
            Public Property Qty() As String
                Get
                    Return _Qty
                End Get
                Set(ByVal value As String)
                    _Qty = value
                End Set
            End Property

            Private _QtyUnit As String
            Public Property QtyUnit() As String
                Get
                    Return _QtyUnit
                End Get
                Set(ByVal value As String)
                    _QtyUnit = value
                End Set
            End Property
        End Class

        Public Class ArrestIndictment
            Private _ArrestIndictmentDetail As List(Of ArrestIndictmentDetail)
            Public Property ArrestIndictmentDetail() As List(Of ArrestIndictmentDetail)
                Get
                    Return _ArrestIndictmentDetail
                End Get
                Set(ByVal value As List(Of ArrestIndictmentDetail))
                    _ArrestIndictmentDetail = value
                End Set
            End Property

            Private _ArrestLawGuitbase As List(Of ArrestLawGuitbase)
            Public Property ArrestLawGuitbase() As List(Of ArrestLawGuitbase)
                Get
                    Return _ArrestLawGuitbase
                End Get
                Set(ByVal value As List(Of ArrestLawGuitbase))
                    _ArrestLawGuitbase = value
                End Set
            End Property
        End Class

        Public Class ArrestIndictmentDetail
            Private _ArrestLawbreaker As List(Of ArrestLawbreaker)
            Public Property ArrestLawbreaker() As List(Of ArrestLawbreaker)
                Get
                    Return _ArrestLawbreaker
                End Get
                Set(ByVal value As List(Of ArrestLawbreaker))
                    _ArrestLawbreaker = value
                End Set
            End Property
        End Class

        Public Class ArrestLawGuitbase
            Private _GuiltBaseName As String
            Public Property GuiltBaseName() As String
                Get
                    Return _GuiltBaseName
                End Get
                Set(ByVal value As String)
                    _GuiltBaseName = value
                End Set
            End Property
        End Class

        Public Class ArrestLawbreaker
            Private _EntityType As Integer
            Public Property EntityType() As Integer
                Get
                    Return _EntityType
                End Get
                Set(ByVal value As Integer)
                    _EntityType = value
                End Set
            End Property

            Private _LawbreakerTitleName As String
            Public Property LawbreakerTitleName() As String
                Get
                    Return _LawbreakerTitleName
                End Get
                Set(ByVal value As String)
                    _LawbreakerTitleName = value
                End Set
            End Property

            Private _LawbreakerFirstName As String
            Public Property LawbreakerFirstName() As String
                Get
                    Return _LawbreakerFirstName
                End Get
                Set(ByVal value As String)
                    _LawbreakerFirstName = value
                End Set
            End Property

            Private _LawbreakerMiddleName As String
            Public Property LawbreakerMiddleName() As String
                Get
                    Return _LawbreakerMiddleName
                End Get
                Set(ByVal value As String)
                    _LawbreakerMiddleName = value
                End Set
            End Property

            Private _LawbreakerLastName As String
            Public Property LawbreakerLastName() As String
                Get
                    Return _LawbreakerLastName
                End Get
                Set(ByVal value As String)
                    _LawbreakerLastName = value
                End Set
            End Property

            Private _LawbreakerOtherName As String
            Public Property LawbreakerOtherName() As String
                Get
                    Return _LawbreakerOtherName
                End Get
                Set(ByVal value As String)
                    _LawbreakerOtherName = value
                End Set
            End Property

            Private _CompanyTitle As String
            Public Property CompanyTitle() As String
                Get
                    Return _CompanyTitle
                End Get
                Set(ByVal value As String)
                    _CompanyTitle = value
                End Set
            End Property

            Private _CompanyName As String
            Public Property CompanyName() As String
                Get
                    Return _CompanyName
                End Get
                Set(ByVal value As String)
                    _CompanyName = value
                End Set
            End Property

            Private _CompanyOtherName As String
            Public Property CompanyOtherName() As String
                Get
                    Return _CompanyOtherName
                End Get
                Set(ByVal value As String)
                    _CompanyOtherName = value
                End Set
            End Property
        End Class

    End Class
End Namespace
