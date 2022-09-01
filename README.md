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

For running test you neeed following steps:
1.  https://github.com/igor-kadach/ui-tests-csharp-selenium-nunit - сlone the project to your repository. 
2.  Selenium.WebDriver.ChromeDriver v.104.0.5112.7900 - download from NuGet Package Manager and install in the copied project.
3.  Seleium.WebDriver v.4.4.0 - download from NuGet Package Manager and install in the copied project.
4.  NUnit v.3.13.1 - download from NuGet Package Manager and install in the copied project.

Tests executed from UnitTest1.cs. in package "Tests".
May need to be added following usings:
* using NUnit.Framework;
* using OpenQA.Selenium;
* using OpenQA.Selenium.Chrome;
* using SeleniumExtras.PageObjects;
* using System.Threading;
* using UITests.PageObjects;


# ***Running Tests***

Tool → Command Line → Developer Command Prompt

* Install-Package NUnit -Version 3.13.2
* Install-Package NUnit.Allure -Version 1.2.1.1
* Install-Package NUnit3TestAdapter -Version 3.17.0
* Install-Package Selenium.Support -Version 4.4.0
* Install-Package Selenium.WebDriver -Version 4.4.0
* Install-Package Selenium.WebDriver.ChromeDriver -Version 104.0.5112.7900
* Install-Package SeleniumFramework -Version 1.0.6




to be continued...
