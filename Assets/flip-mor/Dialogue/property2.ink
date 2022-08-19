INCLUDE globals.ink

{ purchased: -> purchased | -> main}

=== main ===
Welcome to 24385 CRESTLAWN ST, WOODLAND HILLS!
This single family residence (SFR) has 4 bedrooms and 2 bathrooms.
It has 1,936 sq ft and was built in 1962.
-> purchase_decision

=== purchase_decision ===
This property costs $120,000 Would you like to purchase?
    + [Yes]
        -> purchased
    + [No]
        -> declined

=== purchased ===
{ moneyCount == 0.5:
    Sorry, you don't have enough Ruimies.
    -> declined
}
~ price = "120000"
The cost of the property has been taken from your loan.
Thanks for your purchase.
-> rehab

=== rehab ===
You must consider the interior and exterior property valuation. 
You should consider the flooring, kitchen, bedroom, bathroom, garage, and utilities 
~ price = "170000"
The cost of rehabilitation is $50,000 and has been taken from your loan.
-> sale_decision

=== sale_decision ===
This property is now valued at $200,000 Would you like to list now or wait?
    + [List now, I want my money!]
        -> winner
    + [I'll see if the market improves]
        -> loser

=== declined ===
Thanks for stopping by. See you later. 
-> END

=== loser ===
~ salePrice = "130000"
Unfortunately, your property only sold for $130,000, which leaves you with a net loss of $40,000.
->END

=== winner ===
~ salePrice = "160000"
Your property sold for $160,000!
Keep on trakc with your investment choices, and apply your skills
at dunmor.com and experience the world for Fix and Flip!
->END