# uitests-pagefactory

# ***About***

This project presents automated UI-tests using Page Object and Page Factory patterns for website https://av.by/. The project was completed using the following tecnology stacks:
  1. Chrome WebDriver.
  2. Selenium
  3. NUnit
  4. C#


# ***Getting Started***


The project is made in Microsoft Visual Studio Community 2019 Version 16.11.2.
Programming language C#.

# ***Running Tests***

Please, install following packages:

Tool → Command Line → Developer Command Prompt

* Install-Package NUnit -Version 3.13.2
* Install-Package NUnit.Allure -Version 1.2.1.1
* Install-Package NUnit3TestAdapter -Version 3.17.0
* Install-Package Selenium.Support -Version 4.4.0
* Install-Package Selenium.WebDriver -Version 4.4.0
* Install-Package Selenium.WebDriver.ChromeDriver -Version 104.0.5112.7900
* Install-Package SeleniumFramework -Version 1.0.6


# ***Allure***
Required for ***Allure*** installation:

Open ***Windows PowerShell*** and type ***command set-executionpolicy RemoteSigned -scope CurrentUser***

After accepting all policies, install Allure:

In ***Windows PowerShell*** type command ***scoop install allure***

>It nescessary to have in System variables JAVA_HOME path: C:\Program Files\Java\jdk-15.0.1

After running test go to Windows PowerShell and type command ***allure serve PATH to folder Allure-Result*** in cloned project e.x. C:\Users\Igor\source\repos\uitests-pagefactory\uitests-pagefactory\UITests\Allure-Results

to be continued...
