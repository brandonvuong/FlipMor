INCLUDE globals.ink

{ moneyCount == 0.5: -> main | -> already_chose}

-> main

=== main ===
How much do you want to borrow?
    + [500000]
        -> chosen("500000")
    + [1000000]
        -> chosen("1000000")

=== chosen(money) ===
~ moneyCount = money
Enjoy your {money}! You better earn it back or else! >:)
-> END

=== already_chose ===
Why are you still here? 
-> END