class Integer

    def is_prime?
        temp = Math.sqrt(self).ceil
        (2..temp).each{|i|
            return false if (self%i ==0);
        }
        return true;
    end

    def factorial
        return 1 if self == 0
        return self * (self-1).factorial
    end

    def to_digits
        self.to_s.split('').collect{|x| x.to_i}
    end

end

