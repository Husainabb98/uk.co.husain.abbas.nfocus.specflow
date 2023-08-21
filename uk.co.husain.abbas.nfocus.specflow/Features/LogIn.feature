Feature: logging in

Background: I am on the edgewords homepage
 

Scenario: logging into edgewords with correct credentials 
     
    When I enter the logging information
    Then I should be logged in

Scenario: logging into edgewords with incorrect credentials
   
    When I enter the wrong logging information
    Then I should not be logged in