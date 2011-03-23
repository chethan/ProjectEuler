#2520 is the smallest number that can be divided by each of the numbers from 1 to 10
#without any remainder.
#What is the smallest number that is evenly divisible by all of the numbers from 1 to 20?


class Problem_Five
    TARGET=20

    def self.mine
        index=TARGET;
        while true
            break if divisable?(index)
            index+=1
        end
        p index
    end

    def self.euler
        product=1;
        limit=Math.sqrt(TARGET).ceil
        [2, 3, 5, 7, 11, 13, 17,19].each{|prime_number|
            power=1;
            power=(Math.log(TARGET)/Math.log(prime_number)).to_i if prime_number <=limit
            product = product * (prime_number ** power)
        }
        p product
    end

    def self.divisable? (number)
        2.upto(TARGET){|i|
            return false unless (number%i == 0)
        }
        return true
    end

end

Problem_Five.mine
Problem_Five.euler

