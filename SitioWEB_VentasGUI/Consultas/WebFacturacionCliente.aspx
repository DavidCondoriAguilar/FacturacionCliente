<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="WebFacturacionCliente.aspx.cs" Inherits="SitioWEB_VentasGUI.Consultas.WebFacturacionCliente" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <p class="tituloForm">
        Consultas de facturas por cliente- fechas
    </p>
    <br />

      <table width="1000px">
        <tr>
            <td class="labelContenido" >Ingrese cliente:</td>
            <td width="150px" class="auto-style5">
                <asp:TextBox ID="txtCod" runat="server" CssClass="TextBoxDerecha" MaxLength="4" Width="70px"></asp:TextBox>
            &nbsp;
                <asp:ImageButton ID="btnBuscar" runat="server" ImageUrl="~/Images/Buscar.png" style="width: 16px" CausesValidation="False" OnClick="btnBuscar_Click"   />
            </td>
            <td class="auto-style4">
                </td>
            <td class="auto-style4">
                </td>
        </tr>
        <tr>
            <td class="labelContenido">Razon Social</td>
            <td>
                <asp:TextBox ID="txtRazSoc" runat="server" CssClass="TextBoxDerecha" Width="300px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="labelContenido">RUC:</td>
            <td>
                <asp:TextBox ID="txtRUC" runat="server" CssClass="TextBoxDerecha" Width="120px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelContenido">Direccion:</td>
            <td>
                <asp:TextBox ID="txtDir" runat="server" CssClass="TextBoxDerecha" Width="300px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="labelContenido">Ubigeo:</td>
            <td>
                <asp:TextBox ID="txtUbicacion" runat="server" CssClass="TextBoxDerecha" Width="300px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelContenido">Telefono:</td>
            <td >
                <asp:TextBox ID="txtTel" runat="server" CssClass="TextBoxDerecha" Width="120px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="labelContenido">Estado:</td>
            <td >
                <asp:TextBox ID="txtEstado" runat="server" CssClass="TextBoxDerecha" Width="120px" ReadOnly="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelContenido">Deuda:</td>
            <td >
                <asp:TextBox ID="txtDeuda" runat="server" CssClass="TextBoxDerecha" Width="120px" ReadOnly="True"></asp:TextBox>
            </td>
            <td class="labelContenido"></td>
            <td ></td>
        </tr>
        <tr>
            <td class="labelTitulo" colspan="4">INGRESE FECHAS DE CONSULTA ( * Obligatorios):</td>
        </tr>
        <tr>
            <td class="labelTitulo">Fecha inicio (*):</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtFecIni" runat="server" CssClass="TextBoxDerecha" Width="100px"></asp:TextBox>
                
                
                
                <ajaxToolkit:CalendarExtender ID="txtFecIni_CalendarExtender" runat="server" BehaviorID="txtFecIni_CalendarExtender" TargetControlID="txtFecIni">
                </ajaxToolkit:CalendarExtender>
                
                
                
            </td>
            <td class="labelTitulo" >Fecha fin (*):</td>
            <td class="auto-style2">
                <asp:TextBox ID="txtFecFin" runat="server" CssClass="TextBoxDerecha" Width="100px"></asp:TextBox>
                
               
                
                <ajaxToolkit:CalendarExtender ID="txtFecFin_CalendarExtender" runat="server" BehaviorID="txtFecFin_CalendarExtender" TargetControlID="txtFecFin">
                </ajaxToolkit:CalendarExtender>
                
               
                
            </td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style4">
                <asp:Button ID="btnConsultar" runat="server" CssClass="boton2" Text="Consultar" OnClick="btnConsultar_Click"  />
            </td>
            <td class="auto-style2">
                <asp:Button ID="btnDescargar" runat="server" CssClass="boton2" Text="DescargarPDF" OnClick="btnConsultar_Click"  />
                </td>
            <td class="auto-style2">
                <%--3.El Modal popup que hace referencia al control target  (1) y al panel (2)--%>
                </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblRegistros" runat="server" CssClass="labelErrores"></asp:Label>
            </td>
            <td >
                </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Consultas/Consultas.aspx">Retornar</asp:HyperLink>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        </table>

    <asp:GridView ID="grvFacturas" runat="server" AutoGenerateColumns="False" CellPadding="4" GridLines="None" Width="919px" ForeColor="#333333" ShowHeaderWhenEmpty="True">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Num_fac" HeaderText="Nro.Factura" />
            <asp:BoundField DataField="Fec_fac" DataFormatString="{0:d}" HeaderText="Fec.Facturacion">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Fec_can" DataFormatString="{0:d}" HeaderText="Fec_cancelacion">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Total" DataFormatString="{0:n}" HeaderText="Total S/.">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Estado" HeaderText="Estado">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="ApellNom_ven" HeaderText="Vendedor">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

    <%--Este es el modal popup  que contiene los mensajes --%>
                <%--1. Control target (cualquier control)--%>
              <asp:LinkButton ID="lnkMensaje" runat="server" ></asp:LinkButton>
                 <%--2. El panel que se mostrara en el popup--%>
              <asp:Panel ID="pnlMensaje" runat="server" CssClass="CajaDialogo" Style="display: normal;" Width="500"> 
                    <table border="0" width="500px" style="margin: 0px; padding: 0px; background-color:darkred ; 
                        color: #FFFFFF;"> 
                        <tr> 
                            <td align="center"> 
                                <asp:Label ID="lblTitulo" runat="server" Text="Mensaje" /> 
                            </td> 
                            <td width="12%" class="center"> 
                                <asp:ImageButton ID="btnCerrar" runat="server" ImageUrl="~/Images/Cancelar.png" Style="vertical-align: top;" 
                                    ImageAlign="Right" /> 
                            </td> 
                        </tr> 
                         
                    </table>
                  <div>
                      <br />
                  </div>
                    <div> 
                        <asp:Label ID="lblMensajePopup" runat="server" CssClass="labelTitulo"  /> 
                    </div> 
                  <div>
                       <br />
                  </div>
                    <div> 
                        <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" CausesValidation="False" CssClass="boton-new" /> 
                    </div> 
                   <div>
                       <br />
                  </div>
                </asp:Panel> 
         <%--3.El Modal popup que hace referencia al control target  (1) y al panel (2)--%>
                <ajaxToolkit:ModalPopupExtender ID="PopMensaje" runat="server" TargetControlID="lnkMensaje" 
                    PopupControlID="pnlMensaje" BackgroundCssClass="FondoAplicacion"  OkControlID="btnAceptar" />
</asp:Content>
