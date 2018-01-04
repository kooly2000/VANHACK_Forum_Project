<%@ Control Language="C#"       AutoEventWireup="true" CodeBehind="UC_User_ADD.ascx.cs" Inherits="VANHACK_Forum_Project.UserControl.UC_User_ADD" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<form>
  <div class="form-group">
    <label class="col-form-label" for="EmailInput">Email</label>
    <input type="text" class="form-control" id="EmailInput" placeholder="Email">
  </div>
  <div class="form-group">
    <label class="col-form-label" for="User_NameInput">User Name</label>
    <input type="text" class="form-control" id="User_NameInput" maxlength="8" placeholder="User name should not exceed 8 characters">
  </div>
      <div class="form-group">
    <label class="col-form-label" for="PasswordInput">Password</label>
    <input type="text" class="form-control" id="PasswordInput" maxlength="8" placeholder="Password">
  </div>
      <div class="form-group">
    <label class="col-form-label" for="User_NameInput">User Name</label>
    <input type="text" class="form-control" id="User_NameInput" maxlength="8" placeholder="User name should not exceed 8 characters">
  </div>
</form>--%>
<br />
<div data-toggle="validator" role="form">
  <div class="form-group">
    <label for="inputName" class="control-label">Name</label>
    <input type="text" class="form-control"  runat="server" id="inputName" placeholder="Aiman Alkoli" required>
  </div>
<%--  <div class="form-group has-feedback">
    <label for="inputTwitter" class="control-label">Twitter</label>
    <div class="input-group">
      <span class="input-group-addon">@</span>
      <input type="text" pattern="^[_A-z0-9]{1,}$" maxlength="15" class="form-control" id="inputTwitter" placeholder="1000hz" required>
    </div>
    <span class="glyphicon form-control-feedback" aria-hidden="true"></span>
    <div class="help-block with-errors">Hey look, this one has feedback icons!</div>
  </div>--%>
 
  <div class="form-group">
    <label for="inputEmail" class="control-label">Email</label>
    <input type="email" runat="server" runat="server" maxlength="100" class="form-control" id="inputEmail" placeholder="Email" data-error="Email address is invalid" required>
    <div class="help-block with-errors"></div>
  </div>
  <div class="form-group">
    <label for="inputPassword" class="control-label">Password:<div class="help-block" style="font-size:12px;">Minimum of 6 characters (UpperCase, LowerCase and Number)</div>
</label>
    <div class="form-inline row">
      <div class="form-group col-sm-6">
        <input runat="server" type="password" data-min-length="6" runat="server" pattern="(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$" class="form-control" id="inputPassword" placeholder="Password " required>

      </div>
      <div class="form-group col-sm-6">
        <input type="password" runat="server"    class="form-control" id="inputPasswordConfirm" data-match="#inputPassword" data-match-error="Paswords don't match" placeholder="Confirm" required>
        <div class="help-block with-errors"></div>        

      </div>
            <asp:CompareValidator ValidationGroup="_A" ID="CompareValidator1" runat="server" ErrorMessage="Passwords don't match" ControlToCompare="inputPasswordConfirm" ControlToValidate="inputPassword" ForeColor="Red"></asp:CompareValidator>

    </div>
  </div>
  <%--<div class="form-group">
    <div class="radio">
      <label>
        <input type="radio" name="underwear" required>
        Boxers
      </label>
    </div>
    <div class="radio">
      <label>
        <input type="radio" name="underwear" required>
        Briefs
      </label>
    </div>
  </div>--%>
<%--  <div class="form-group">
    <div class="checkbox">
      <label>
        <input type="checkbox" id="terms" data-error="Before you wreck yourself" required>
        Check yourself
      </label>
      <div class="help-block with-errors"></div>
    </div>
  </div>
--%> 
     <div class="form-group">
    <label for="inputEmail" class="control-label">Birth Date</label>
    <telerik:raddatepicker class="form-control" runat="server" id="DatePicker1" required></telerik:raddatepicker>
          
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DatePicker1" ErrorMessage="Please fill Birth Date " ForeColor="Red" ValidationGroup="_A"></asp:RequiredFieldValidator>
          
    <div class="help-block with-errors"></div>
  </div>

     <div class="form-group">
<%--    <asp:button  id="btnSubmit" runat="server" class= "btn btn-primary">Submit</asp:button>--%>
         <asp:Button ID="Button1" class="btn btn-primary" ValidationGroup="_A" runat="server" Text="Join" OnClick="Button1_Click" />
  </div>
</div>