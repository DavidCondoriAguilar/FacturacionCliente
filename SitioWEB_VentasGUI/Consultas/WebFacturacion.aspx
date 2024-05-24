<%@ Page Title="" Language="C#" MasterPageFile="~/DemoMaster.Master" AutoEventWireup="true" CodeBehind="WebFacturacion.aspx.cs" Inherits="SitioWEB_VentasGUI.Consultas.WebFacturacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cabecera" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 82%;
        }
        .auto-style2 {
            width: 204px;
        }
        .auto-style3 {
            width: 209px;
        }
        .auto-style4 {
            width: 248px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Principal" runat="server">
    <h1 class="tituloForm">Consulta de facturacion por vendedor- fechas</h1>
    <table class="auto-style1">
        <tr>
            <td class="labelContenido">Selecciona vendedor:</td>
            <td class="auto-style3">
                <asp:DropDownList ID="cboVendedores" runat="server" CssClass="DropDownList" Width="200px">
                </asp:DropDownList>
            </td>
            <td class="auto-style4">&nbsp;</td>
        </tr>
        <tr>
            <td class="labelContenido">Ingrese fecha inicio:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtFecInicio" runat="server" CssClass="TextBoxDerecha"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFecInicio_CalendarExtender" runat="server" BehaviorID="txtFecInicio_CalendarExtender" TargetControlID="txtFecInicio" />
            </td>
            <td class="labelContenido">y de fin:
                <asp:TextBox ID="txtFecFin" runat="server" CssClass="TextBoxDerecha"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="txtFecFin_CalendarExtender" runat="server" BehaviorID="txtFecInicio0_CalendarExtender" TargetControlID="txtFecFin" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="btnConsultar" runat="server" CssClass="box_white" Text="Calcular" OnClick="btnConsultar_Click" />
            </td>
            <td class="auto-style4">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblRegistros" runat="server" CssClass="labelErrores"></asp:Label>
            </td>
        </tr>
    </table>

    <%--3.El Modal popup que hace referencia al control target  (1) y al panel (2)--%>
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
         <asp:BoundField DataField="Raz_soc_cli" HeaderText="Cliente">
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
