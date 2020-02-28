Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Shopping
Scenario: AmazonShopping 
	Given My Framework is ready
	And I am an existing Amazon User
	And I am logged to Amazon
	When I search for following product Samsung Galaxy S9 64GB
	And I select first found product
	And I add Item to cart 
	And I open Cart 
	Then Compare prices 1 vs 2 
	And Compare prices 1 vs 3 
	And Cart should display count as 1
	When I search for following product Alienware
	And I select first found product
	And I add Item to cart 
	Then Cart should display count as 2
	And Finally test is completed
