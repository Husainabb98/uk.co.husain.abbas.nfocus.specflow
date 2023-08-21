Feature: apply coupon


 

Scenario: applying coupon on the items in cart
    Given that i am logged in 
    When I have items in cart 
    And i navigate to the cart page and click apply coupon
    Then the discount should be applied 

