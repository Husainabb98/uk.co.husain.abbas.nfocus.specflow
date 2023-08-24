Feature: apply coupon

AS a user, I want to be able to apply a vaild a coupon 
so that I can get the correct discounted price
 

Scenario Outline: Applying coupon on the items in cart
    Given that the user is logged in
    And the user has '<items>' in the cart
    When the user applies the coupon 'edgewords'
    Then the discount '15'% should be applied 
    Examples: 
    | items  |
    | Cap    |
    | Polo   |
    | Tshirt |

