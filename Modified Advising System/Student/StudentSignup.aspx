<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentSignup.aspx.cs" Inherits="Modified_Advising_System.StudentSignup" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Sign Up</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-image: url('background.jpg'); 
            background-size: cover;
            background-repeat: no-repeat;
            color: #000; /* Set text color to black */
            text-align: center;
            margin-top: 50px;
        }

        #form1 {
            width: 300px;
            margin: 0 auto;
            background-color: rgba(255, 255, 255);
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .auto-style1 {
            font-size: xx-large;
            margin-bottom: 20px;
            color: #000;
        }

        input[type="text"],
        input[type="password"] {
            width: 100%;
            padding: 8px;
            margin: 8px 0;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        #btnSignUp {
            width: 100%;
            padding: 10px;
            background-color: #3498db;
            color: #fff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        #btnSignUp:hover {
            background-color: #2980b9;
        }

        #lnkSignIn {
            text-decoration: none;
            color: #000;
            display: block;
            margin-top: 10px;
            transition: color 0.3s;
        }

        #lnkSignIn:hover {
            color: #333;
        }

        .error-message {
            color: #ff0000;
            margin-top: 5px;
        }

        .switch-user-button {
        position: absolute;
        top: 10px;
        left: 10px;
        text-decoration: none;
        background-color: #e74c3c; /* Red background color for the button */
        color: white; /* White text color */
        padding: 8px 16px;
        font-weight: bold;
        transition: color 0.3s;
        }

        .switch-user-button:hover {
            color: #c0392b;
        }


    </style>

    <script>
        function validateForm() {
            var firstName = document.getElementById('<%= txtFirstname.ClientID %>').value;
            var lastName = document.getElementById('<%= txtLastName.ClientID %>').value;
            var password = document.getElementById('<%= txtPassword.ClientID %>').value;
            var faculty = document.getElementById('<%= txtFaculty.ClientID %>').value;
            var email = document.getElementById('<%= txtEmail.ClientID %>').value;
            var major = document.getElementById('<%= txtMajor.ClientID %>').value;
            var semester = document.getElementById('<%= txtSemester.ClientID %>').value;



            // Empty field validation
            if (firstName === '' || lastName === '' || password === '' || faculty === '' || email === '' || major === '' || semester === '') {
                document.getElementById('emptyFieldError').innerText = 'All fields must be filled';
                return false;
            } else {
                document.getElementById('emptyFieldError').innerText = '';
            }



            // Type validation
            if (isNaN(faculty) === false) {
                document.getElementById('facultyError').innerText = 'Faculty must be of the correct data type';
                return false;
            } else {
                document.getElementById('facultyError').innerText = '';
            }


            // Email validation
            var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailRegex.test(email)) {
                document.getElementById('emailError').innerText = 'Invalid email format';
                return false;
            } else {
                document.getElementById('emailError').innerText = '';
            }

            // Type validation
            if (isNaN(major) === false ) {
                document.getElementById('majorError').innerText = 'Major must be of the correct data type';
                return false;
            } else {
                document.getElementById('majorError').innerText = '';
            }


            // Type validation
            if (isNaN(semester) === true) {
                document.getElementById('semError').innerText = 'Semester must be an integer';
                return false;
            } else {
                document.getElementById('semError').innerText = '';
            }

            return true;
        }
    </script>
</head>
<body>
    
    <form id="form1" runat="server" onsubmit="return validateForm()">
        <div>            
            <div class="auto-style1">Student Sign Up</div>
            <p>
                First Name:<asp:TextBox ID="txtFirstname" runat="server" placeholder="First Name"></asp:TextBox>
            </p>
            <p>
                Last Name:<asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name"></asp:TextBox>

            </p>
            <p>
                Password:<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            </p>
            <p>
                Faculty:<asp:TextBox ID="txtFaculty" runat="server" placeholder="Faculty"></asp:TextBox>
                <span id="facultyError" class="error-message"></span>
            </p>
            <p>
                Email:<asp:TextBox ID="txtEmail" runat="server" placeholder="Email"></asp:TextBox>
                <span id="emailError" class="error-message"></span>
            </p>
            <p>
                Major:<asp:TextBox ID="txtMajor" runat="server" placeholder="Major"></asp:TextBox>
                <span id="majorError" class="error-message"></span>
            </p>
            <p>
                Semester:<asp:TextBox ID="txtSemester" runat="server" placeholder="Semester"></asp:TextBox>
                <span id="semError" class="error-message"></span>
            </p>
            <asp:Button ID="btnSignUp" runat="server" OnClick="signup" Text="Sign Up" />
            <br />
            <asp:HyperLink ID="lnkSignIn" runat="server" NavigateUrl="StudentLogin.aspx">Already have an account? Sign In</asp:HyperLink>
            <span id="emptyFieldError" class="error-message"></span>
        </div>
    </form>
</body>
</html>
