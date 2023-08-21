
Feature: Checkout order


 

Scenario: Verifying the order number
    Given I have proceeded to checkout
    When I when i billing information and i place order
    And I navigate to my account and view orders
    Then order number should same