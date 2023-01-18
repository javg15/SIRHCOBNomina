Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports DataAccessLayer.COBAEV.Administracion
Namespace COBAEV
    Public Class DataCOBAEV

        Public Enum Tipoconsulta
            Reader = 0
            View = 1
            Table = 2
            DataRow = 3
        End Enum
        Public Enum BD
            Administracion = 0
            Nomina = 1
            MovsPersonal = 2
        End Enum
        Public Function setDataSetRecibosImportesPercepciones() As DataSet
            Try
                Dim dsResultado As New DataSet
                Dim dtResultado As DataTable = New DataTable("Resultado")

                Dim PrimaryKeys(1) As DataColumn

                Dim dcIdPercDeduc As DataColumn
                Dim dcClavePercDeduc As DataColumn
                Dim dcNombrePercDeduc As DataColumn
                Dim dcImporte As DataColumn
                Dim dcImporteParaRetroactivo As DataColumn
                Dim dcImporteParaAguinaldo As DataColumn

                dcIdPercDeduc = New DataColumn
                dcIdPercDeduc.DataType = System.Type.GetType("System.Int16")
                dcIdPercDeduc.ColumnName = "IdPercDeduc"
                dcIdPercDeduc.Caption = "IdPercDeduc"

                dcClavePercDeduc = New DataColumn
                dcClavePercDeduc.DataType = System.Type.GetType("System.String")
                dcClavePercDeduc.MaxLength = 3
                dcClavePercDeduc.ColumnName = "ClavePercDeduc"
                dcClavePercDeduc.Caption = "Clave"

                dcNombrePercDeduc = New DataColumn
                dcNombrePercDeduc.DataType = System.Type.GetType("System.String")
                dcNombrePercDeduc.MaxLength = 50
                dcNombrePercDeduc.ColumnName = "NombrePercDeduc"
                dcNombrePercDeduc.Caption = "NombrePercDeduc"

                dcImporte = New DataColumn
                dcImporte.DataType = System.Type.GetType("System.Decimal")
                dcImporte.ColumnName = "Importe"
                dcImporte.Caption = "Importe"

                dcImporteParaRetroactivo = New DataColumn
                dcImporteParaRetroactivo.DataType = System.Type.GetType("System.Decimal")
                dcImporteParaRetroactivo.ColumnName = "ImporteParaRetroactivo"
                dcImporteParaRetroactivo.Caption = "Importe para retroactivo"

                dcImporteParaAguinaldo = New DataColumn
                dcImporteParaAguinaldo.DataType = System.Type.GetType("System.Decimal")
                dcImporteParaAguinaldo.ColumnName = "ImporteParaAguinaldo"
                dcImporteParaAguinaldo.Caption = "Importe para aguinaldo"

                PrimaryKeys(0) = dcIdPercDeduc

                dtResultado.Columns.Add(dcIdPercDeduc)
                dtResultado.Columns.Add(dcClavePercDeduc)
                dtResultado.Columns.Add(dcNombrePercDeduc)
                dtResultado.Columns.Add(dcImporte)
                dtResultado.Columns.Add(dcImporteParaRetroactivo)
                dtResultado.Columns.Add(dcImporteParaAguinaldo)

                dtResultado.PrimaryKey = PrimaryKeys

                dsResultado.Tables.Add(dtResultado)

                Return dsResultado
            Catch ex As Exception
                Throw New System.Exception("Error:" & ex.Message.ToString)
            End Try
        End Function
        Public Function setDataSetErrsCalculoNomina() As DataSet
            Try
                Dim dsResultado As New DataSet
                Dim dtResultado As DataTable = New DataTable("Resultado")

                'Dim PrimaryKeys(1) As DataColumn

                Dim dcRFC As DataColumn
                Dim dcDescripcion As DataColumn


                dcRFC = New DataColumn
                dcRFC.DataType = System.Type.GetType("System.String")
                dcRFC.MaxLength = 13
                dcRFC.ColumnName = "RFC"
                dcRFC.Caption = "RFC"

                dcDescripcion = New DataColumn
                dcDescripcion.DataType = System.Type.GetType("System.String")
                dcDescripcion.MaxLength = 5000
                dcDescripcion.ColumnName = "Descripcion"
                dcDescripcion.Caption = "Descripcion"

                dtResultado.Columns.Add(dcRFC)
                dtResultado.Columns.Add(dcDescripcion)

                dsResultado.Tables.Add(dtResultado)

                Return dsResultado
            Catch ex As Exception
                Throw New System.Exception("Error:" & ex.Message.ToString)
            End Try
        End Function
        Public Function setDataSetErrores() As DataSet
            Try
                Dim dsResultado As New DataSet
                Dim dtResultado As DataTable = New DataTable("Resultado")

                Dim PrimaryKeys(1) As DataColumn

                Dim dcIdError As DataColumn
                Dim dcDescripcion As DataColumn

                dcIdError = New DataColumn
                dcIdError.DataType = System.Type.GetType("System.Int32")
                dcIdError.ColumnName = "IdError"
                dcIdError.Caption = "Error"

                dcDescripcion = New DataColumn
                dcDescripcion.DataType = System.Type.GetType("System.String")
                dcDescripcion.MaxLength = 1000
                dcDescripcion.ColumnName = "Descripcion"
                dcDescripcion.Caption = "Descripcion"

                PrimaryKeys(0) = dcIdError

                dtResultado.Columns.Add(dcIdError)
                dtResultado.Columns.Add(dcDescripcion)

                dtResultado.PrimaryKey = PrimaryKeys

                dsResultado.Tables.Add(dtResultado)

                Return dsResultado
            Catch ex As Exception
                Throw New System.Exception("Error:" & ex.Message.ToString)
            End Try
        End Function
        Public Function setDataSetPercepcionesMasivas() As DataSet
            Try
                Dim dsPercepcionesMasivas As New DataSet
                Dim dtPercepcionesMasivas As DataTable = New DataTable("PercepcionesMasivas")

                Dim PrimaryKeys(1) As DataColumn

                Dim dcNumEmp As DataColumn
                Dim dcImportePercepcion As DataColumn
                Dim dcNumQnas As DataColumn
                Dim dcIdQnaIni As DataColumn
                Dim dcInicio As DataColumn
                Dim dcIdQnaFin As DataColumn
                Dim dcFin As DataColumn

                dcNumEmp = New DataColumn
                dcNumEmp.DataType = System.Type.GetType("System.String")
                dcNumEmp.ColumnName = "NumEmp"
                dcNumEmp.Caption = "Número de empleado"

                dcImportePercepcion = New DataColumn
                dcImportePercepcion.DataType = System.Type.GetType("System.Decimal")
                dcImportePercepcion.ColumnName = "ImportePercepcion"
                dcImportePercepcion.Caption = "Importe a pagar"

                dcNumQnas = New DataColumn
                dcNumQnas.DataType = System.Type.GetType("System.Byte")
                dcNumQnas.ColumnName = "NumQnas"
                dcNumQnas.Caption = "Número de quincenas"

                dcIdQnaIni = New DataColumn
                dcIdQnaIni.DataType = System.Type.GetType("System.Int16")
                dcIdQnaIni.ColumnName = "IdQnaIni"
                dcIdQnaIni.Caption = "IdQnaIni"

                dcInicio = New DataColumn
                dcInicio.DataType = System.Type.GetType("System.String")
                dcInicio.ColumnName = "Inicio"
                dcInicio.Caption = "Inicio"

                dcIdQnaFin = New DataColumn
                dcIdQnaFin.DataType = System.Type.GetType("System.Int16")
                dcIdQnaFin.ColumnName = "IdQnaFin"
                dcIdQnaFin.Caption = "IdQnaFin"

                dcFin = New DataColumn
                dcFin.DataType = System.Type.GetType("System.String")
                dcFin.ColumnName = "Fin"
                dcFin.Caption = "Fin"

                PrimaryKeys(0) = dcNumEmp

                dtPercepcionesMasivas.Columns.Add(dcNumEmp)
                dtPercepcionesMasivas.Columns.Add(dcImportePercepcion)
                dtPercepcionesMasivas.Columns.Add(dcNumQnas)
                dtPercepcionesMasivas.Columns.Add(dcIdQnaIni)
                dtPercepcionesMasivas.Columns.Add(dcInicio)
                dtPercepcionesMasivas.Columns.Add(dcIdQnaFin)
                dtPercepcionesMasivas.Columns.Add(dcFin)

                dtPercepcionesMasivas.PrimaryKey = PrimaryKeys

                dsPercepcionesMasivas.Tables.Add(dtPercepcionesMasivas)

                Return dsPercepcionesMasivas
            Catch ex As Exception
                Throw New System.Exception("Error:" & ex.Message.ToString)
            End Try
        End Function

        Public Function setDataSetDeduccionesMasivas() As DataSet
            Try
                Dim dsDeduccionesMasivas As New DataSet
                Dim dtDeduccionesMasivas As DataTable = New DataTable("DeduccionesMasivas")

                Dim PrimaryKeys(1) As DataColumn

                Dim dcNumEmp As DataColumn
                Dim dcImporteDeduccion As DataColumn
                Dim dcNumQnas As DataColumn
                Dim dcIdQnaIni As DataColumn
                Dim dcInicio As DataColumn
                Dim dcIdQnaFin As DataColumn
                Dim dcFin As DataColumn

                dcNumEmp = New DataColumn
                dcNumEmp.DataType = System.Type.GetType("System.String")
                dcNumEmp.ColumnName = "NumEmp"
                dcNumEmp.Caption = "Número de empleado"

                dcImporteDeduccion = New DataColumn
                dcImporteDeduccion.DataType = System.Type.GetType("System.Decimal")
                dcImporteDeduccion.ColumnName = "ImporteDeduccion"
                dcImporteDeduccion.Caption = "Importe a descontar"

                dcNumQnas = New DataColumn
                dcNumQnas.DataType = System.Type.GetType("System.Int16")
                dcNumQnas.ColumnName = "NumQnas"
                dcNumQnas.Caption = "Número de quincenas"

                dcIdQnaIni = New DataColumn
                dcIdQnaIni.DataType = System.Type.GetType("System.Int16")
                dcIdQnaIni.ColumnName = "IdQnaIni"
                dcIdQnaIni.Caption = "IdQnaIni"

                dcInicio = New DataColumn
                dcInicio.DataType = System.Type.GetType("System.String")
                dcInicio.ColumnName = "Inicio"
                dcInicio.Caption = "Inicio"

                dcIdQnaFin = New DataColumn
                dcIdQnaFin.DataType = System.Type.GetType("System.Int16")
                dcIdQnaFin.ColumnName = "IdQnaFin"
                dcIdQnaFin.Caption = "IdQnaFin"

                dcFin = New DataColumn
                dcFin.DataType = System.Type.GetType("System.String")
                dcFin.ColumnName = "Fin"
                dcFin.Caption = "Fin"

                PrimaryKeys(0) = dcNumEmp

                dtDeduccionesMasivas.Columns.Add(dcNumEmp)
                dtDeduccionesMasivas.Columns.Add(dcImporteDeduccion)
                dtDeduccionesMasivas.Columns.Add(dcNumQnas)
                dtDeduccionesMasivas.Columns.Add(dcIdQnaIni)
                dtDeduccionesMasivas.Columns.Add(dcInicio)
                dtDeduccionesMasivas.Columns.Add(dcIdQnaFin)
                dtDeduccionesMasivas.Columns.Add(dcFin)

                dtDeduccionesMasivas.PrimaryKey = PrimaryKeys

                dsDeduccionesMasivas.Tables.Add(dtDeduccionesMasivas)

                Return dsDeduccionesMasivas
            Catch ex As Exception
                Throw New System.Exception("Error:" & ex.Message.ToString)
            End Try
        End Function
        Public Function setDataSetDeduccionesMasivas2() As DataSet
            Try
                Dim dsDeduccionesMasivas As New DataSet
                Dim dtDeduccionesMasivas As DataTable = New DataTable("DeduccionesMasivas")

                Dim PrimaryKeys(1) As DataColumn

                Dim dcNumEmp As DataColumn
                Dim dcImporteDeduccion As DataColumn
                Dim dcNumQnas As DataColumn
                Dim dcIdQnaIni As DataColumn
                Dim dcInicio As DataColumn
                Dim dcIdQnaFin As DataColumn
                Dim dcFin As DataColumn
                Dim dcTipoOrden As DataColumn
                Dim dcNumPrestamo As DataColumn
                Dim dcConcepto As DataColumn
                Dim dcIdDeduccion As DataColumn

                dcNumEmp = New DataColumn
                dcNumEmp.DataType = System.Type.GetType("System.String")
                dcNumEmp.ColumnName = "CURPEmp"
                dcNumEmp.Caption = "CURP del empleado"

                dcImporteDeduccion = New DataColumn
                dcImporteDeduccion.DataType = System.Type.GetType("System.Decimal")
                dcImporteDeduccion.ColumnName = "ImporteDeduccion"
                dcImporteDeduccion.Caption = "Importe a descontar"

                dcNumQnas = New DataColumn
                dcNumQnas.DataType = System.Type.GetType("System.Int16")
                dcNumQnas.ColumnName = "NumQnas"
                dcNumQnas.Caption = "Número de quincenas"

                dcIdQnaIni = New DataColumn
                dcIdQnaIni.DataType = System.Type.GetType("System.Int16")
                dcIdQnaIni.ColumnName = "IdQnaIni"
                dcIdQnaIni.Caption = "IdQnaIni"

                dcInicio = New DataColumn
                dcInicio.DataType = System.Type.GetType("System.String")
                dcInicio.ColumnName = "Inicio"
                dcInicio.Caption = "Inicio"

                dcIdQnaFin = New DataColumn
                dcIdQnaFin.DataType = System.Type.GetType("System.Int16")
                dcIdQnaFin.ColumnName = "IdQnaFin"
                dcIdQnaFin.Caption = "IdQnaFin"

                dcFin = New DataColumn
                dcFin.DataType = System.Type.GetType("System.String")
                dcFin.ColumnName = "Fin"
                dcFin.Caption = "Fin"

                dcTipoOrden = New DataColumn
                dcTipoOrden.DataType = System.Type.GetType("System.String")
                dcTipoOrden.ColumnName = "TipoOrden"
                dcTipoOrden.Caption = "Tipo de orden"

                dcNumPrestamo = New DataColumn
                dcNumPrestamo.DataType = System.Type.GetType("System.String")
                dcNumPrestamo.ColumnName = "NumPrestamo"
                dcNumPrestamo.Caption = "Número de préstamo"

                dcConcepto = New DataColumn
                dcConcepto.DataType = System.Type.GetType("System.String")
                dcConcepto.ColumnName = "Concepto"
                dcConcepto.Caption = "Concepto"

                dcIdDeduccion = New DataColumn
                dcIdDeduccion.DataType = System.Type.GetType("System.Int16")
                dcIdDeduccion.ColumnName = "IdDeduccion"
                dcIdDeduccion.Caption = "IdDeduccion"

                PrimaryKeys(0) = dcNumEmp
                PrimaryKeys(1) = dcTipoOrden

                dtDeduccionesMasivas.Columns.Add(dcNumEmp)
                dtDeduccionesMasivas.Columns.Add(dcImporteDeduccion)
                dtDeduccionesMasivas.Columns.Add(dcNumQnas)
                dtDeduccionesMasivas.Columns.Add(dcIdQnaIni)
                dtDeduccionesMasivas.Columns.Add(dcInicio)
                dtDeduccionesMasivas.Columns.Add(dcIdQnaFin)
                dtDeduccionesMasivas.Columns.Add(dcFin)
                dtDeduccionesMasivas.Columns.Add(dcTipoOrden)
                dtDeduccionesMasivas.Columns.Add(dcNumPrestamo)
                dtDeduccionesMasivas.Columns.Add(dcConcepto)
                dtDeduccionesMasivas.Columns.Add(dcIdDeduccion)

                dtDeduccionesMasivas.PrimaryKey = PrimaryKeys

                dsDeduccionesMasivas.Tables.Add(dtDeduccionesMasivas)

                Return dsDeduccionesMasivas
            Catch ex As Exception
                Throw New System.Exception("Error:" & ex.Message.ToString)
            End Try
        End Function

        Public Function setDataSetInconsistenciasDeducMasivas() As DataSet
            Try
                Dim dsDeduccionesMasivas As New DataSet
                Dim dtDeduccionesMasivas As DataTable = New DataTable("InconsistenciasDeducMasivas")

                Dim PrimaryKeys(1) As DataColumn

                Dim dcNumEmp As DataColumn
                Dim dcImporteDeduccion As DataColumn
                Dim dcNumQnas As DataColumn
                Dim dcObservaciones As DataColumn
                Dim dcIdError As DataColumn

                dcNumEmp = New DataColumn
                dcNumEmp.DataType = System.Type.GetType("System.String")
                dcNumEmp.ColumnName = "NumEmp"
                dcNumEmp.Caption = "Número de empleado"

                dcImporteDeduccion = New DataColumn
                dcImporteDeduccion.DataType = System.Type.GetType("System.String")
                dcImporteDeduccion.ColumnName = "ImporteDeduccion"
                dcImporteDeduccion.Caption = "Importe a descontar"

                dcNumQnas = New DataColumn
                dcNumQnas.DataType = System.Type.GetType("System.Int16")
                dcNumQnas.ColumnName = "NumQnas"
                dcNumQnas.Caption = "Número de quincenas"

                dcObservaciones = New DataColumn
                dcObservaciones.DataType = System.Type.GetType("System.String")
                dcObservaciones.ColumnName = "Observaciones"
                dcObservaciones.Caption = "Observaciones"

                dcIdError = New DataColumn
                dcIdError.DataType = System.Type.GetType("System.Int16")
                dcIdError.ColumnName = "IdError"
                dcIdError.Caption = "IdError"

                PrimaryKeys(0) = dcNumEmp

                dtDeduccionesMasivas.Columns.Add(dcNumEmp)
                dtDeduccionesMasivas.Columns.Add(dcImporteDeduccion)
                dtDeduccionesMasivas.Columns.Add(dcNumQnas)
                dtDeduccionesMasivas.Columns.Add(dcObservaciones)
                dtDeduccionesMasivas.Columns.Add(dcIdError)

                dtDeduccionesMasivas.PrimaryKey = PrimaryKeys

                dsDeduccionesMasivas.Tables.Add(dtDeduccionesMasivas)

                Return dsDeduccionesMasivas
            Catch ex As Exception
                Throw New System.Exception("Error:" & ex.Message.ToString)
            End Try
        End Function
        Public Function setDataSetInconsistenciasDeducMasivas2() As DataSet
            Try
                Dim dsDeduccionesMasivas As New DataSet
                Dim dtDeduccionesMasivas As DataTable = New DataTable("InconsistenciasDeducMasivas")

                Dim PrimaryKeys(1) As DataColumn

                Dim dcNumEmp As DataColumn
                Dim dcImporteDeduccion As DataColumn
                Dim dcNumQnas As DataColumn
                Dim dcObservaciones As DataColumn
                Dim dcIdError As DataColumn
                Dim dcTipoOrden As DataColumn
                Dim dcNumPrestamo As DataColumn
                Dim dcConcepto As DataColumn
                Dim dcIdDeduccion As DataColumn

                dcNumEmp = New DataColumn
                dcNumEmp.DataType = System.Type.GetType("System.String")
                dcNumEmp.ColumnName = "CURPEmp"
                dcNumEmp.Caption = "CURP del empleado"

                dcImporteDeduccion = New DataColumn
                dcImporteDeduccion.DataType = System.Type.GetType("System.Decimal")
                dcImporteDeduccion.ColumnName = "ImporteDeduccion"
                dcImporteDeduccion.Caption = "Importe a descontar"

                dcNumQnas = New DataColumn
                dcNumQnas.DataType = System.Type.GetType("System.String")
                dcNumQnas.ColumnName = "NumQnas"
                dcNumQnas.Caption = "Número de quincenas"

                dcObservaciones = New DataColumn
                dcObservaciones.DataType = System.Type.GetType("System.String")
                dcObservaciones.ColumnName = "Observaciones"
                dcObservaciones.Caption = "Observaciones"

                dcIdError = New DataColumn
                dcIdError.DataType = System.Type.GetType("System.Int16")
                dcIdError.ColumnName = "IdError"
                dcIdError.Caption = "IdError"

                dcTipoOrden = New DataColumn
                dcTipoOrden.DataType = System.Type.GetType("System.String")
                dcTipoOrden.ColumnName = "TipoOrden"
                dcTipoOrden.Caption = "Tipo de orden"

                dcNumPrestamo = New DataColumn
                dcNumPrestamo.DataType = System.Type.GetType("System.String")
                dcNumPrestamo.ColumnName = "NumPrestamo"
                dcNumPrestamo.Caption = "Número de préstamo"

                dcConcepto = New DataColumn
                dcConcepto.DataType = System.Type.GetType("System.String")
                dcConcepto.ColumnName = "Concepto"
                dcConcepto.Caption = "Concepto"

                dcIdDeduccion = New DataColumn
                dcIdDeduccion.DataType = System.Type.GetType("System.Int16")
                dcIdDeduccion.ColumnName = "IdDeduccion"
                dcIdDeduccion.Caption = "IdDeduccion"

                PrimaryKeys(0) = dcNumEmp
                PrimaryKeys(1) = dcTipoOrden

                dtDeduccionesMasivas.Columns.Add(dcNumEmp)
                dtDeduccionesMasivas.Columns.Add(dcImporteDeduccion)
                dtDeduccionesMasivas.Columns.Add(dcNumQnas)
                dtDeduccionesMasivas.Columns.Add(dcObservaciones)
                dtDeduccionesMasivas.Columns.Add(dcIdError)
                dtDeduccionesMasivas.Columns.Add(dcTipoOrden)
                dtDeduccionesMasivas.Columns.Add(dcNumPrestamo)
                dtDeduccionesMasivas.Columns.Add(dcConcepto)
                dtDeduccionesMasivas.Columns.Add(dcIdDeduccion)

                dtDeduccionesMasivas.PrimaryKey = PrimaryKeys

                dsDeduccionesMasivas.Tables.Add(dtDeduccionesMasivas)

                Return dsDeduccionesMasivas
            Catch ex As Exception
                Throw New System.Exception("Error:" & ex.Message.ToString)
            End Try
        End Function
        Public Function setDataSetInconsistenciasPercMasivas() As DataSet
            Try
                Dim dsPercepcionesMasivas As New DataSet
                Dim dtPercepcionesMasivas As DataTable = New DataTable("InconsistenciasPercMasivas")

                Dim PrimaryKeys(1) As DataColumn

                Dim dcNumEmp As DataColumn
                Dim dcImportePercepcion As DataColumn
                Dim dcNumQnas As DataColumn
                Dim dcObservaciones As DataColumn
                Dim dcIdError As DataColumn

                dcNumEmp = New DataColumn
                dcNumEmp.DataType = System.Type.GetType("System.String")
                dcNumEmp.ColumnName = "NumEmp"
                dcNumEmp.Caption = "Número de empleado"

                dcImportePercepcion = New DataColumn
                dcImportePercepcion.DataType = System.Type.GetType("System.String")
                dcImportePercepcion.ColumnName = "ImportePercepcion"
                dcImportePercepcion.Caption = "Importe a pagar"

                dcNumQnas = New DataColumn
                dcNumQnas.DataType = System.Type.GetType("System.String")
                dcNumQnas.ColumnName = "NumQnas"
                dcNumQnas.Caption = "Número de quincenas"

                dcObservaciones = New DataColumn
                dcObservaciones.DataType = System.Type.GetType("System.String")
                dcObservaciones.ColumnName = "Observaciones"
                dcObservaciones.Caption = "Observaciones"

                dcIdError = New DataColumn
                dcIdError.DataType = System.Type.GetType("System.Int16")
                dcIdError.ColumnName = "IdError"
                dcIdError.Caption = "IdError"

                PrimaryKeys(0) = dcNumEmp

                dtPercepcionesMasivas.Columns.Add(dcNumEmp)
                dtPercepcionesMasivas.Columns.Add(dcImportePercepcion)
                dtPercepcionesMasivas.Columns.Add(dcNumQnas)
                dtPercepcionesMasivas.Columns.Add(dcObservaciones)
                dtPercepcionesMasivas.Columns.Add(dcIdError)

                dtPercepcionesMasivas.PrimaryKey = PrimaryKeys

                dsPercepcionesMasivas.Tables.Add(dtPercepcionesMasivas)

                Return dsPercepcionesMasivas
            Catch ex As Exception
                Throw New System.Exception("Error:" & ex.Message.ToString)
            End Try
        End Function
#Region "SQL SERVER 2005 (GENERAL)"
        Private Overloads Function BuildInCommand(ByVal StoredProcName As String, ByVal Parameters As IDataParameter()) As SqlCommand
            Try
                Dim Command As SqlCommand = BuildQueryCommand(StoredProcName, Parameters)
                Dim Parameter As New SqlParameter
                With Parameter
                    .ParameterName = "ReturnValue"
                    .DbType = CType(SqlDbType.Int, DbType)
                    .Size = 4
                    .Direction = ParameterDirection.ReturnValue
                    .Precision = 0
                    .Scale = 0
                    .SourceColumn = String.Empty
                    .SourceVersion = DataRowVersion.Default
                    .Value = Nothing
                End With
                Command.Parameters.Add(Parameter)
                Return Command
            Catch ex As Exception
                Throw New System.Exception("Error: " & ex.Message.ToString)
            End Try
        End Function

        Private Overloads Function BuildInCommand(ByVal StoredProcName As String) As SqlCommand
            Try
                Dim Command As SqlCommand = BuildQueryCommand(StoredProcName)
                Dim Parameter As New SqlParameter
                With Parameter
                    .ParameterName = "ReturnValue"
                    .DbType = CType(SqlDbType.Int, DbType)
                    .Size = 4
                    .Direction = ParameterDirection.ReturnValue
                    .Precision = 0
                    .Scale = 0
                    .SourceColumn = String.Empty
                    .SourceVersion = DataRowVersion.Default
                    .Value = Nothing
                End With
                Command.Parameters.Add(Parameter)
                Return Command
            Catch ex As Exception
                Throw New System.Exception("Error: " & ex.Message.ToString)
            End Try
        End Function

        Private Overloads Function BuildQueryCommand(ByVal StoredProcName As String, ByVal Parameters As IDataParameter()) As SqlCommand
            Try
                Dim Command As New SqlCommand(StoredProcName)
                Command.CommandType = CommandType.StoredProcedure
                Command.CommandTimeout = 0
                Dim Parameter As SqlParameter
                If Parameters Is Nothing Then
                    Return Command
                Else
                    For Each Parameter In Parameters
                        Command.Parameters.Add(Parameter)
                    Next
                    Return Command
                End If
            Catch ex As Exception
                Throw New System.Exception("Error: " & ex.Message.ToString)
            End Try
        End Function

        Private Overloads Function BuildQueryCommand(ByVal StoredProcName As String) As SqlCommand
            Try
                Dim Command As New SqlCommand(StoredProcName)
                Command.CommandType = CommandType.StoredProcedure
                Return Command
            Catch ex As Exception
                Throw New System.Exception("Error: " & ex.Message.ToString)
            End Try
        End Function

        Private Function BuildQueryString(ByVal SQLStr As String) As SqlCommand
            Try
                Dim Command As New SqlCommand(SQLStr)
                Command.CommandType = CommandType.Text
                Return Command
            Catch ex As Exception
                Throw New System.Exception("Error: " & ex.Message.ToString)
            End Try
        End Function
#End Region

#Region "SQL SERVER 2005"
        Private Function dsCOBAEV(ByVal Cmd As SqlCommand, ByVal BD As String) As DataSet
            Dim oCon As New Conexion
            Try
                Cmd.Connection = oCon.AbrirCnnBD(BD)
                Dim oSQLDA As New SqlDataAdapter(Cmd)
                Dim ds As New DataSet
                oSQLDA.Fill(ds)
                dsCOBAEV = ds
                oCon.CerrarCnnBD()
            Catch ex As Exception
                oCon.CerrarCnnBD()
                Throw New System.Exception("Error: " & ex.Message.ToString)
            End Try
        End Function

        Private Function boCOBAEV(ByVal Cmd As SqlCommand, ByVal BD As String) As Boolean
            Dim oCon As New Conexion
            Try
                Cmd.CommandTimeout = 0
                Cmd.Connection = oCon.AbrirCnnBD(BD)
                boCOBAEV = Cmd.ExecuteScalar
                oCon.CerrarCnnBD()
            Catch ex As Exception
                oCon.CerrarCnnBD()
                Throw New System.Exception("Error: " & ex.Message.ToString)
            End Try
        End Function

        Private Function reCOBAEV(ByVal Cmd As SqlCommand, ByVal BD As String) As SqlDataReader
            Dim oCon As New Conexion
            Try
                Cmd.Connection = oCon.AbrirCnnBD(BD)
                reCOBAEV = Cmd.ExecuteReader
                oCon.CerrarCnnBD()
            Catch ex As Exception
                oCon.CerrarCnnBD()
                Throw New System.Exception("Error: " & ex.Message.ToString)
            End Try
        End Function

        Private Function dtCOBAEV(ByVal Cmd As SqlCommand, ByVal BD As String) As DataTable
            Dim oCon As New Conexion
            Try
                Cmd.CommandTimeout = 0
                Cmd.Connection = oCon.AbrirCnnBD(BD)
                Dim oSQLDA As New SqlDataAdapter(Cmd)
                Dim ds As New DataSet
                oSQLDA.Fill(ds)
                dtCOBAEV = ds.Tables(0)
                oCon.CerrarCnnBD()
            Catch ex As Exception
                oCon.CerrarCnnBD()
                Throw New System.Exception("Error: " & ex.Message.ToString)
            End Try
        End Function
        Public Overloads Function RunProc(ByVal StoredProcName As String, ByVal Parameters As IDataParameter(), ByVal BD As BD) As Boolean
            Try
                Dim Command As SqlCommand = BuildInCommand(StoredProcName, Parameters)
                If boCOBAEV(Command, BD.ToString) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw New System.Exception("Error al ejecutar el SP " & StoredProcName & ", " & ex.Message.ToString)
            End Try
        End Function
        Public Overloads Function RunProc(ByVal StoredProcName As String, ByVal Parameters As IDataParameter(), ByVal BD As BD, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim oAuditoria As New Auditoria
                Dim _DataCOBAEV As New DataCOBAEV

                ArregloAuditoria(2) = StoredProcName

                oAuditoria.InsertaRegistro(ArregloAuditoria, Parameters)

                Dim Command As SqlCommand = BuildInCommand(StoredProcName, Parameters)
                If boCOBAEV(Command, BD.ToString) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw New System.Exception("Error al ejecutar el SP " & StoredProcName & ", " & ex.Message.ToString)
            End Try
        End Function
        Public Overloads Function RunProc(ByVal StoredProcName As String, ByVal BD As BD) As Boolean
            Try
                Dim Command As SqlCommand = BuildInCommand(StoredProcName)
                If boCOBAEV(Command, BD.ToString) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw New System.Exception("Error al ejecutar el SP " & StoredProcName & ", " & ex.Message.ToString)
            End Try
        End Function
        Public Overloads Function RunProc(ByVal StoredProcName As String, ByVal BD As BD, ByVal ArregloAuditoria() As String) As Boolean
            Try
                Dim oAuditoria As New Auditoria
                Dim _DataCOBAEV As New DataCOBAEV

                ArregloAuditoria(2) = StoredProcName

                oAuditoria.InsertaRegistro(ArregloAuditoria)

                Dim Command As SqlCommand = BuildInCommand(StoredProcName)
                If boCOBAEV(Command, BD.ToString) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw New System.Exception("Error al ejecutar el SP " & StoredProcName & ", " & ex.Message.ToString)
            End Try
        End Function

        Public Overloads Function RunProc(ByVal StoredProcName As String, ByVal Parameters As IDataParameter(), ByVal RetObj As Tipoconsulta, ByVal BD As BD) As Object
            Try
                If RetObj = Tipoconsulta.Reader Then
                    Dim ReturnReader As SqlDataReader
                    Dim Command As SqlCommand = BuildQueryCommand(StoredProcName, Parameters)
                    Command.CommandType = CommandType.StoredProcedure
                    ReturnReader = reCOBAEV(Command, BD.ToString)
                    Return ReturnReader
                ElseIf RetObj = Tipoconsulta.View Then
                    Dim xData As New DataSet
                    Dim Command As SqlCommand
                    Command = BuildQueryCommand(StoredProcName, Parameters)
                    xData = dsCOBAEV(Command, BD.ToString)
                    Dim xView As New DataView(xData.Tables(0))
                    Return xView
                ElseIf RetObj = Tipoconsulta.Table Then
                    Dim xTable As New DataTable
                    Dim Command As SqlCommand
                    Command = BuildQueryCommand(StoredProcName, Parameters)
                    xTable = dtCOBAEV(Command, BD.ToString)
                    Return xTable
                ElseIf RetObj = Tipoconsulta.DataRow Then
                    Dim xTable As New DataTable
                    Dim Command As SqlCommand
                    Command = BuildQueryCommand(StoredProcName, Parameters)
                    xTable = dtCOBAEV(Command, BD.ToString)
                    If xTable.Rows.Count > 0 Then
                        Return xTable.Rows(0)
                    Else
                        Return Nothing
                    End If
                    Else
                        Return 0
                    End If
            Catch ex As Exception
                Throw New System.Exception("Error al ejecutar el SP " & StoredProcName & ", " & ex.Message.ToString)
            End Try
        End Function

        Public Overloads Function RunProc(ByVal StoredProcName As String, ByVal RetObj As Tipoconsulta, ByVal BD As BD) As Object
            Try
                If RetObj = Tipoconsulta.Reader Then
                    Dim ReturnReader As SqlDataReader
                    Dim Command As SqlCommand = BuildQueryCommand(StoredProcName)
                    Command.CommandType = CommandType.StoredProcedure
                    ReturnReader = reCOBAEV(Command, BD.ToString)
                    Return ReturnReader
                ElseIf RetObj = Tipoconsulta.View Then
                    Dim xData As New DataSet
                    Dim Command As SqlCommand
                    Command = BuildQueryCommand(StoredProcName)
                    xData = dsCOBAEV(Command, BD.ToString)
                    Dim xView As New DataView(xData.Tables(0))
                    Return xView
                ElseIf RetObj = Tipoconsulta.Table Then
                    Dim xTable As New DataTable
                    Dim Command As SqlCommand
                    Command = BuildQueryCommand(StoredProcName)
                    xTable = dtCOBAEV(Command, BD.ToString)
                    Return xTable
                ElseIf RetObj = Tipoconsulta.DataRow Then
                    Dim xTable As New DataTable
                    Dim Command As SqlCommand
                    Command = BuildQueryCommand(StoredProcName)
                    xTable = dtCOBAEV(Command, BD.ToString)
                    Return xTable.Rows(0)
                Else
                    Return 0
                End If
            Catch ex As Exception
                Throw New System.Exception("Error al ejecutar el SP " & StoredProcName & ", " & ex.Message.ToString)
            End Try
        End Function

        Public Overloads Function RunProc(ByVal StoredProcName As String, ByVal Parameters As IDataParameter(), ByVal TableName As String, ByVal BD As BD) As DataSet
            Try
                Dim xData As New DataSet(TableName)
                Dim Command As SqlCommand
                Command = BuildQueryCommand(StoredProcName, Parameters)
                xData = dsCOBAEV(Command, BD.ToString)
                Return xData
            Catch ex As Exception
                Throw New System.Exception("Error al ejecutar el SP " & StoredProcName & ", " & ex.Message.ToString)
            End Try
        End Function

        Public Overloads Function RunProc(ByVal StoredProcName As String, ByVal TableName As String, ByVal BD As BD) As DataSet
            Try
                Dim xData As New DataSet(TableName)
                Dim Command As SqlCommand
                Command = BuildQueryCommand(StoredProcName)
                xData = dsCOBAEV(Command, BD.ToString)
                Return xData
            Catch ex As Exception
                Throw New System.Exception("Error al ejecutar el SP " & StoredProcName & ", " & ex.Message.ToString)
            End Try
        End Function

        Public Overloads Function RunQueryStr(ByVal SQLStr As String, ByVal TableName As String, ByVal BD As BD) As DataSet
            Try
                Dim xData As New DataSet
                Dim command As SqlCommand = BuildQueryString(SQLStr)
                xData = dsCOBAEV(command, BD.ToString)
                Return xData
            Catch ex As Exception
                Throw New System.Exception("Error al ejecutar la consulta " & SQLStr & ", " & ex.Message.ToString)
            End Try
        End Function

        Public Overloads Function RunQueryStr(ByVal SQLStr As String, ByVal BD As BD) As Boolean
            Try
                Dim xData As New DataSet
                Dim Command As SqlCommand = BuildQueryString(SQLStr)
                If boCOBAEV(Command, BD.ToString) Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw New System.Exception("Error al ejecutar la consulta " & SQLStr & ", " & ex.Message.ToString)
            End Try
        End Function
#End Region
    End Class
End Namespace
