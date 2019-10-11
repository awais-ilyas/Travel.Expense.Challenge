# Introduction
 Trivago Travel Expense Challenge aims to automate the finance department manual worksheet with cutting edge technologies facilities the employees to submit their trip expenses,
 team leaders can approve or reject those expense of their relevant members of team and finance manager should notified by email whenever a Travel expense being submitted,
 s/he can see a user-friendly interface of web application to view overall reporting of employees Travel expense submitted and also export in excel sheet.

# Getting Started
This project uses the latest tools available at the time of development. It is being built on Visual Studio 2017 enterprise edition.
1. Configuration process: ASP.NET Core 2.2 SDK shoould be install on machine, in order to access the project.
2. Software dependencies: All dependencies are taken care off by the Nuget Packages, thus on first built all the required packages will get downloaded and installed.
3. Please run 'Update-Database' command in Package Manager Console in order to create a database and seed data.
4. Please change the smtp credential in appsettings.json file in order to send an email.
4. I have created 3 different types of users role (Employee, TeamLeader and FinanceManager).
	Role: Employee 1;   Awais Ilyas (awais.i@outlook.com) - Supervior/TeamLeader: jsmith@domain.com
	Role: Employee 2;   Jonas Klein (jklein@domain.com) - Supervior/TeamLeader: jdoe@domain.com
	Role: TeamLeader 1; John Smith (jsmith@domain.com)
	Role: TeamLeader 2; John Doe (jdoe@domain.com)
	Role: FinanceManager; Kevin Arnold (karnold@domain.com)

5. Submit a Travel Expense:
	Employee can give a valid email address in order to login to application and upload an expense by giving a photo and expense title. By default expense status will be 'Pending' and an automated email will be send to Finance Manager.
6. Team Leader
	Team Leader can login and see only his team members expenses and approve/reject each expense.
7. Finance Manager
	He will login with his valid email address and see all the expenses along with their respective status. He can also click on 'Export to Excel' button to download the excel sheet of all the expenses.

# Contribute
You can always contribute to this file and/or to the project with your suggestions.

Please refer to the following URLs followed in the architecture development:
- [ASP.NET Core] https://github.com/aspnet/AspNetCore
- [Generic Repository Pattern In ASP.NET Core] https://www.c-sharpcorner.com/article/generic-repository-pattern-in-asp-net-core/
- [RazorLight] https://github.com/toddams/RazorLight/blob/master/README.md
- [Mapping in ASP.NET Core 2.2 ] http://anthonygiretti.com/2018/12/19/common-features-in-asp-net-core-2-2-webapi-mapping/
- [Import and Export excel in ASP.NET Core 2.0 Razor Pages] https://www.talkingdotnet.com/import-export-excel-asp-net-core-2-razor-pages/
