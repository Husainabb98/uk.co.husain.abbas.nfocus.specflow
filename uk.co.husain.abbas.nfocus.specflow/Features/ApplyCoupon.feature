Feature: Apply coupon and proceed to checkout

AS a user, I want to be able to apply a vaild a coupon 
so that I can get the correct discounted price and proceed to checkout

Background: 
Given that the user is logged in
 
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
    Given the user has proceeded to checkout
    When the user enters billing information and places order
    And the user navigates to my account and view orders
    Then the order number should be the same

