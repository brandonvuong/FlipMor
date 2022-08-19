INCLUDE globals.ink
{ moneyCount == 0.5: ... | {moneyCount}}


-> main

=== main ===
Hi, my name is Mark, SENIOR Product Manager, and I'll be your tour guide around FlipMor. Stop galking, and let’s start this sh*t
-> FlipTour

=== FlipTour === //mark
In the world of FlipMor, there is an abudnance of houses just waiting to get fixed, and then flipped. It's going to be your job to take on one of these projects to make FlipMor a better place and your pockets bigger.
-> Ready

=== Ready ===//mark
Are you ready to embark on the journey of a lifetime?
* Yes
    -> Yes
    
===Yes===//mark
F*ck yeah, so on a high level a Fix-and Flip is simply when you buy a property, improve it, then sell it really quickly.
+ Got, it
   -> EasySh1t

===EasySh1t===//mark
That’s easy sh*t, right? but I’m sure you’re wondering, when does the money come in? Ok, so the reason why fix-and-flips are quick, is because of hard-money lending which allows for loan terms to be as short as 6 to 12 months. While traditional home loans take 15 to 30 years to pay off!
+ Ok, so how much money do I need??
 -> DunmorisClutch
 
 ===DunmorisClutch===//mark
 The Rule of Thumb is the follow the 70% rule: Maximum Offer Price = After Repair Value * 70% – Repair Costs. 
 + Let's see an example
    -> Example
 ===Example===//mark
 If a home should sell for around $400k in good condition and you estimate that the repairs will cost an additional $50k, then with  the formula: 

Max offer = $400,000(.70) – $50,000 = $230,000 should be the price of a property you are trying to fix and flip
+ I'm getting it
-> Costs
+ Easy sh*t
-> Costs

=== Costs ===//mark
So, formula is easy but how do we get these numbers? The After Repair Value (ARV) can be provided with online calculators, and the costs can be reduced to just 5 areas.

+ What are da 5 areas?
-> 5Areas

===5Areas=== //mark

Closing Costs: 3 – 6% of the cost of the home
Renovation Costs: Range from $10k to $100k in most cases.
Carrying Costs: 10 – 15% of the project cost.
Selling Costs: 3 – 6% of the sales price.
Unexpected Costs: 1 – 2% of the sales price

+ A lot of percents, but I'll be ok
-> ChooseLoan
+That's it? Hell ya, let's the loan

-> ChooseLoan

===ChooseLoan=== //mark
I'm gonna give you 3 loan options to make the 70% rule easier and to get a feel of typical loan amounts.
+Let's f*cking see it
->LoanAmounts
+Bet
->LoanAmounts

===LoanAmounts===
100k Ruimies: Smaller house, less repair costs
500k Rumies: Bigger house, same amount of repair costs or more


+ [100000]
    -> chosen("100000")
+ [500000]
    -> chosen("500000")



===100k ===
On the map, you will see a selection of properties that pertain to your 100K loan amount, you will soon be given the money to make your Fix, and Flip
->100k

===500k ===
On the map, you will see a selection of properties that pertain to your 500K loan amount, you will soon be given the money to make your Fix,
and Flip
->500k
=== chosen(money) ===
~ moneyCount = money

Good Luck MOFO (check out dunmor.com)
-> END
