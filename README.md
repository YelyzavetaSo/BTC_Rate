# Program BTC_Rate

## Specifications
Project type: _ASP.NET Web Application (.NET Framework) C#_

Template: Empty, with MVC & Web API
______________________________________________________________________________
## Program files features
Project contains one model _User_, which contains e-mail & pass of the user.

Also, here was defined two controllers: _CreateController_ & _LoginController_. 
* _CreateController_ contains POST controller method, which updates recent recods. That method is using methods, from additional class _UserService_(It will be described later).
* _LoginController_ contains GET controller method, which gets information from file and search a specific user. It is also using methods from additional class, to check, if data base file contains at least specific e-mail.
Controlers, which are designed for processing of HTTP calls, do not work with data base(file system)  directly. They communicate with DB through methods of additional class.

Additional class _UserService_ contains 3 methods, which are called by controllers:
* _`List<Users> GetUsers()`_ - reads DB file, which is in XML format (deserialization). While deserializing, it use explicit typecasting of deserialized data.
* _`bool isContain(string email)`_ - check, if DB contains user with specific e-mail. Returns FALSE if system does not contain it.
* _`void Add(User user)`_ - serialize user data in XML format. At the begining, it recives list of deserialized data & ads new user to the list. Then, that method clears DB to predict duplication of information & writes serialized data in file.

Program contains 4 HTML files: user, create, login & btcRate.
* _`user.html`_ - main page, which contains short description of functional, headers & active links to other pages, which are containing JavaScript codes, which are performing HTTP calls.
* _`create.html`_ - page, which contains JavaScript code to record new user, check, if DB does not contain user with e-mail, which was inserted by user into the text box. After successful record, user is redirected to the user.html. If error occured, this results in a error message being displayed.
*_`login.html`_ - page, which contains JavaScript code to recive user information. If DB contains such user, which was inserted by user into the text box, then it checks if pass is right. In case of success user is redirected to the btcRate.html.If error occured, this results in a error message being displayed. 
*_`btcRate.html`_ - page, which displays BTC Rate in UAH.

Other files of program other parts of the program have not been changed.
______________________________________________________________________________
## Remarks
_Remarks, which contains ideas to improve system._
1. In program should be defined a special class, which will check values & compare it with regular expressions(Regex). It would be used to check 
if entered by the user e-mail & pass entered in the correct format.
2. While program works with DB, while exception handling, here is general exception type is handled. There should be individual exception handlers 
for each exception type possible in that context.
3. There should be encryption and decryption of data, to provide more security.
