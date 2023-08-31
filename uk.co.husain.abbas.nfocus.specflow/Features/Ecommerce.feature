
Feature: Apply coupon and proceed to checkout

AS a user, I want to be able to apply a vaild a coupon 
so that I can get the correct discounted price and proceed to checkout

Background: 
    Given that the user is logged in with correct credentials 'hee@test.co.uk' and 'Testing123456!'
    
 
@Test1
Scenario Outline: Applying coupon on the items in cart
    Given the user has '<items>' in the cart
    When the user applies the coupon 'edgewords'
    Then the discount '15'% should be applied 
    Examples: 
    | items  |
    | Cap    |
    | Polo   |
    | Tshirt |

@Test2
Scenario: Verifying the order number
    Given the user has proceeded to checkout with items in cart
    When the user enters billing information and places order
    | fname | lname | street        | city        | postcode | phone       |
    | go    | gg    | gogogo street | gogogo city | SW15 4JQ | 07777777777 |
    Then the user is given an order number
    And the order number should appear in order history


