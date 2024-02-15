<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="concessionarioProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <asp:DropDownList ID="ddlExample"  DataValueField="null" runat="server">
            <asp:ListItem Value="null">Seleziona un'auto</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Mostra Dettagli"  OnClick="MostraDettagli_click"/>

        <div class="d-flex justify-content-center flex-column">
            <asp:Image ID="Image1" runat="server" CssClass="w-50" />

            <div class="my-3" runat="server" id="contenitoreCheckBox">
                <div>
                    <asp:Label ID="Label1" runat="server" AssociatedControlID="CheckBox1" Text="Aggiungi Cerchi in lega "  />
                    <asp:CheckBox OnCheckedChanged="CheckBox_checked" ID="CheckBox1" runat="server" AutoPostBack="true"/>
                </div>

                <div>
                    <asp:Label ID="Label2" runat="server" AssociatedControlID="CheckBox2" Text="Aggiungi vernice cromata" />
                    <asp:CheckBox OnCheckedChanged="CheckBox_checked" ID="CheckBox2" runat="server"  AutoPostBack="true"/>
                </div>


                <div>
                    <asp:Label ID="Label3" runat="server" AssociatedControlID="CheckBox3" Text="aggiungi climatizzatore " />
                    <asp:CheckBox OnCheckedChanged="CheckBox_checked" ID="CheckBox3" runat="server" AutoPostBack="true"/>
                </div>


                <div>
                    <asp:Label ID="Label4" runat="server" AssociatedControlID="CheckBox4" Text="aggiungi airbag" />
                    <asp:CheckBox OnCheckedChanged="CheckBox_checked" ID="CheckBox4" runat="server" AutoPostBack="true"/>
                </div>
              
            </div>
              <p class="fs-2 fw-bold" runat="server" id="prezzo"></p>

        </div>
     
    </main>

</asp:Content>
