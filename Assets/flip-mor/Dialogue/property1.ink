INCLUDE globals.ink

{ purchased: -> purchased | -> main}

=== main ===
Welcome to 24385 CRESTLAWN ST, WOODLAND HILLS!
This single family residence (SFR) has 4 bedrooms and 2 bathrooms.
It has 1,936 sq ft and was built in 1962.
-> purchase_decision

=== purchase_decision ===
This property costs $55,000 Would you like to purchase?
    + [Yes]
        -> purchased
    + [No]
        -> declined

=== purchased ===
~ moneyCount = moneyCount - 55000
Thanks for your purchase. Good luck!
-> END

=== declined ===
Thanks for stopping by. See you later. 
-> END