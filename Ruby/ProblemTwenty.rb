#n! means n × (n ? 1) × ... × 3 × 2 × 1
#Find the sum of the digits in the number 100!

require "Utils"
class Problem_Twenty
    TARGET=100

    def self.mine
        total=0
        factorial=TARGET.factorial
        factorial.to_s.split('').each{|digit|
            total+=(digit.to_i)
            }
        return total
    end

    def self.euler
    end

end

p Problem_Twenty.mine

