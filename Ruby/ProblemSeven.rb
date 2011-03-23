#By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13,
# we can see that the 6(th) prime is 13.
#What is the 10001  (st) prime number?

require "Utils"

class Problem_Seven
    TARGET=10001

    def self.mine
        number=1;
        count=1;
        while count != TARGET
           count+=1 if number.is_prime?
           number+=2; 
        end
        return number
    end

    def self.euler
    end

end

p Problem_Seven.mine
#Problem_One.euler

