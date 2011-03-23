#The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
#Find the sum of all the primes below two million

require "Utils"
class Problem_Eight
    TARGET=2000000

    def self.mine
       sum=2
       counter=3
       while counter<TARGET
           sum+=counter if counter.is_prime?
           counter+=2
       end
       return sum 
    end

end

p Problem_Eight.mine

