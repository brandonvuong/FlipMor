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
{ moneyCount == 0.5:
    Sorry, you don't have enough Ruimies.
    -> declined
}
~ price = "55000"
The cost of the property has been taken from your loan.
Thanks for your purchase.
-> rehab

=== rehab ===
You must consider the interior and exterior property valuation.
~ price = "75000"
The cost of rehabilitation is $20,000 and has been taken from your loan.
-> sale_decision

=== sale_decision ===
This property is now valued at $80,000 Would you like to list now or wait?
    + [List now, I want my money!]
        -> loser
    + [I'll see if the market improves]
        -> winner

=== declined ===
Thanks for stopping by. See you later. 
-> END

=== loser ===
~ salePrice = "70000"
Unfortunately, your property only sold for $70,000, which leaves you with a net loss of $5,000.
->END

=== winner ===
~ salePrice = "100000"
Your property sold for $100,000!
Keep on trakc with your investment choices, and apply your skills
at dunmor.com and experience the world for Fix and Flip!
->END