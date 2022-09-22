# Stock-Market-WEB

Follow the stocks you care about most and get personalised news and alerts. Access real-time stock information and investment updates to stay on top of the market.
--Follow stocks to get real-time quotes and personalised news
--Discover detailed financial information
--Compare and evaluate stocks with interactive full screen charts

Manual:
--To run the program, you will need to install your own MS SQL server create database and add connection string to the appsettings
--After this you will need to update your database ```dotnet ef database update``` (install EF core tools, if it is not installed ```dotnet tool install -g dotnet-ef```)
--Also, in order to have mailing enabled you will need to add your SendGrid API key to the appsettings

After the following steps you are good to go. Good luck!


## Implemented functionality: 

1. Authorization / registration of new accounts (MSSQL, Blazor authentication)

![img1](https://i.ibb.co/DRy4F5h/1.png)


2. Ability to change password and email after account registration

![img1](https://i.ibb.co/HK6NR39/4.png)


3. Email confirmations, resend email confirmations and password reset by mail (SendGrid email provider)


4. The ability to find a company by ticker with a hint of the name

![img1](https://i.ibb.co/0D9tVTD/3.png)


5. View basic information about the selected company and its status on the stock market

![img1](https://i.ibb.co/kKDs8wm/2.png)


6. Get the main news about the selected companies

![img1](https://i.ibb.co/1s69DTg/5.png)


7. Get information about the current state of the stock market

![img1](https://i.ibb.co/rGQPj5w/6.png)


8. Ability to add companies to favorites list

![img1](https://i.ibb.co/wWLcdY3/7.png)
