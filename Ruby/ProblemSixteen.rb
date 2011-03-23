#2^(15) = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
#What is the sum of the digits of the number 2^(1000)?

require "Utils"
class Problem_Sixteen

    def self.mine
        p (2 ** 1000).to_digits.inject{|sum,i| sum +=i}
    end

end

Problem_Sixteen.mine

