# uitests-pagefactory

# ***About***

This project presents automated UI-tests using Page Object and Page Factory patterns for website https://av.by/. The project was completed using the following tecnology stacks:
  1. Chrome WebDriver.
  2. Selenium
  3. NUnit
  4. C#
  5. .Net 6.0
  6. Allure


# ***Getting Started***


The project is made in Microsoft Visual Studio Community 2022 Version 17.3.3.
Programming language C#.

# ***Running Tests***

Please, install following packages to project from Visual Studio:

Tool → Command Line → Developer Command Prompt

* Install-Package coverlet.collector -Version(3.0.2)
* Install-Package DotNetSeleniumExtras.PageObjects.Core -Version(4.3.0)
* Install-Package Microsoft.NET.TestSdk -Version 17.3.1
* Install-Package Microsoft.TestPlatform -Version 17.3.1
* Install-Package NUnit -Version 3.13.2
* Install-Package NUnit.Allure -Version 1.2.1.1
* Install-Package Selenium.WebDriver.ChromeDriver -Version 104.0.5112.7900
* Install-Package SeleniumFramework -Version 1.0.6

For runnig tests from command line make the following steps:
- Open command promt as Administrator. 
- Change path to file ***vstest.console.exe*** e.x. ***cd C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\Extensions\TestPlatform*** 
- Type folowing command ***vstest.console.exe*** (and path to dll file with tests) e.x. ***vstest.console.exe C:\Users\Igor\source\repos\uitests-pagefactory\UITests\bin\Debug\net5.0\UITests.dll***



# ***Allure***
Required for ***Allure*** installation:

Open ***Windows PowerShell*** and type ***command set-executionpolicy RemoteSigned -scope CurrentUser***

After accepting all policies, install Allure:

In ***Windows PowerShell*** type command ***irm get.scoop.sh | iex*** and after dowloading you can install allure, type command ***scoop install allure***

>It nescessary to have in System variables JAVA_HOME path: C:\Program Files\Java\jdk-15.0.1

After running test go to Windows PowerShell and type command ***allure serve PATH to folder Allure-Result*** in cloned project e.x. allure serve C:\Users\Igor\source\repos\uitests-pagefactory\UITests\bin\Debug\net5.0\allure-results

to be continued....
