#The prime factors of 13195 are 5, 7, 13 and 29.
#What is the largest prime factor of the number 600851475143 ?
require "Utils"
class Problem_Three
    TARGET=600851475143

    def self.mine
        factors=Array.new
        j=0;
        half_of_target=Math.sqrt(TARGET).ceil
        2.upto(half_of_target){|i|
            if (TARGET % i == 0)
                temp=TARGET/i;
                if temp.is_prime?
                    return temp
                end
                j=i if i.is_prime?
            end
        }
        return j
    end

    def self.euler
        n=TARGET
        factor=2
        last_factor=1
        while n>1
            if n%factor == 0
                last_factor=factor
                n/=factor
                while n%factor == 0
                    n/=factor
                end
            end
            factor+=1
        end
        return last_factor
    end

end

p Problem_Three.mine
p Problem_Three.euler

