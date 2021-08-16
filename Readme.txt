# Hi,
I am Sowmya.

This repository holds sample application which is developed using ASP.NET Core MVC, Entity-Framework Core and nUnit Testing.

About Project:
Application is developed to calculate montly premium based on input selection by the user. All the fields are mandatory except Monthly Premium and this field value is populated based on the premium calculation triggred by the "Calculate Premium" button click. The input fields can be reset by another "Reset" button. All the validations are handled on the server side by using data annotations. nUnit Test cases are developed to analyze the code coverage.

The solution folder name is PremiumCalculatorApp.
# This solution can be extended to include Login feature
# First Controller which would be loaded is -"/Premium/Create" - This will take all the inputs which are mandatory and calculate the premium on button click.
# Calculated Premium is displayed in the Monthly Premium field.
# Monthly Premium is displayed in decimal value
# Age is calculated only in years, if it is in months then age is displayed as 0.
# nUnit Test cases coud be found in https://github.com/SowmyaJadhav/PremiumCalculatorApp-UnitTest, and this is part of PremiumCalculatorApp solution.
