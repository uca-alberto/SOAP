<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProteinTracker.aspx.cs" Inherits="HelloWordWebAplication.ProteinTracker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Protein Tracker</title>
	<script src="Scripts/jquery-3.3.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			<label for="select-user">select user</label>
			<select id="select-user" class="form"></select>
        </div>
		<hr />
		<div>
			<h2>Add new User</h2>
			<br />
			<label for="name">Name</label>
			<input id="name" type="text" /><br />
			<label for="goal">goal</label>
			<input id="goal" type="text" /><br />
			<input id="add-new-user-button" type="button" onclick="AddNewUser()" value="Add" /><br />
		</div>

		<div>
			<h2>Add Proteine</h2>
			<br />
			<label for="name">Amount</label>
			<input id="amount" type="text" /><br />
			<label for="name">Name</label>
			<input id="add-new-user-button2" type="button" onclick="AddProtein()" value="Add" /><br />
		</div>
    </form>
	<script type="text/javascript">
		var _user;
		$(document).ready(function () {
			$("#select-user").change(function () {
				UpdateUserData();
			})
			PopulateSelectUser
		});

		function PopulateSelectUser() {
			var selectUser = $('#select-user');
			selectUser.empty();
			 PageMethods.ListUsers(function (users) {
				_user = users;
				for (var i = 0; i < users.length; i++) {
					selectUser.append($("<option></option>")
						.attr("value", users[i].UserId)
						.text(users[i]).Name);	
				}
				UpdateUserData();
			});
		}

		function AddNewUser() {
			var name = $("#name").val();
			var goal = $("#goal").val();

			$.ajax({
				type: "POST",
				url: "ProteinTracker.aspx/AddUser",
				data: JSON.stringify({ 'name': name, 'goal': goal }),
				contentType: 'application/json; charset=utf-8',
				dataType: "json",
				success: PopulateSelectUser
			});

		}
		function AddProtein() {
			var amount = $("#amount").val();
			var userid = $("#select-user").val();
		PageMethods.AddProtein(amount,userid,function (newtotal) {
				_user = users;
			for (var i = 0; i < _user.length; i++) {
				if (_user[i].UserId == userid) {
					_user[i].Total = newtotal;
				}
				}
				UpdateUserData();
			});
		}

		function UpdateUserData() {
			var index = $("select-user")[0].selectedIndex;
			if (index < 0) {
				return;
				$("#user-goal").text(_user[index].goal);
				$("#user-total").text(_user[index].Total);

		}

	</script>
</body>
</html>
