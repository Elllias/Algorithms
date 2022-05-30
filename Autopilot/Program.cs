using System.Text;

namespace Autopilot
{
    class Autopilot
    {
        private static void Main()
        {
            var random = new Random();

            var speedValues = Enum.GetValues(typeof(Speed)).Cast<Speed>().ToArray();
            var distanceValues = Enum.GetValues(typeof(Distance)).Cast<Distance>().ToArray();

            for (var i = 0; i < 10; i++)
            {
                var str = new StringBuilder();
                var speed = (int) speedValues[random.Next(speedValues.Length)];
                var speedNextCar = (int) speedValues[random.Next(speedValues.Length)];
                var distance = (int) distanceValues[random.Next(distanceValues.Length)];

                str.Append($"If the robot speed is {(Speed) speed} ");
                str.Append($"the distance to the vehicle in front is {(Distance) distance} ");
                str.Append($"and the speed of this vehicle is {(Speed) speedNextCar}, ");
                str.Append("then engine power is ");
                str.Append($"{CalculateEnginePower((Speed)speed, (Distance)distance, (Speed)speedNextCar)}");
                Console.WriteLine(str);
            }

            Console.ReadLine();
        }
        
        private static EnginePower CalculateEnginePower(Speed speed, Distance distance, Speed speedNextCar)
        {
            switch (speed)
            {
                case (int) Speed.Stay:
                    switch (speedNextCar)
                    {
                        case Speed.Stay:
                            return distance == Distance.Low ? EnginePower.Zero : EnginePower.Throttle;
                        case Speed.Slow:
                            return distance == Distance.Low ? EnginePower.Zero : EnginePower.Throttle;
                        case Speed.Middle:
                            return distance == Distance.Low ? EnginePower.Zero : EnginePower.Throttle;
                        case Speed.Fast:
                        case Speed.VeryFast: 
                            return distance == Distance.Low ? EnginePower.Zero : EnginePower.FullThrottle;
                    }
                    break;
                
                case Speed.Slow:
                    switch (speedNextCar)
                    {
                        case Speed.Stay:
                            switch (distance)
                            {
                                case Distance.Low:
                                    return EnginePower.FullBrake;
                                case Distance.Middle:
                                    return EnginePower.Zero;
                                case Distance.Big:
                                    return EnginePower.Throttle;
                                case Distance.VeryBig:
                                    return EnginePower.FullThrottle;
                            }
                            break;
                        
                        case Speed.Slow:
                            switch (distance)
                            {
                                case Distance.Low:
                                    return EnginePower.Zero;
                                case Distance.Middle:
                                    return EnginePower.Zero;
                                case Distance.Big:
                                    return EnginePower.Throttle;
                                case Distance.VeryBig:
                                    return EnginePower.FullThrottle;
                            }
                            break;
                        
                        case Speed.Middle:
                            switch (distance)
                            {
                                case Distance.Low:
                                    return EnginePower.Zero;
                                case Distance.Middle:
                                    return EnginePower.Throttle;
                                case Distance.Big:
                                    return EnginePower.Throttle;
                                case Distance.VeryBig:
                                    return EnginePower.FullThrottle;
                            }
                            break;
                        case Speed.Fast:
                        case Speed.VeryFast: 
                            switch (distance)
                            {
                                case Distance.Low:
                                    return EnginePower.Zero;
                                case Distance.Middle:
                                    return EnginePower.Throttle;
                                case Distance.Big:
                                    return EnginePower.FullThrottle;
                                case Distance.VeryBig:
                                    return EnginePower.FullThrottle;
                            }
                            break;
                    }
                    break;
                
                case Speed.Middle:
                    switch (speedNextCar)
                    {
                        case Speed.Stay:
                            switch (distance)
                            {
                                case Distance.Low:
                                    return EnginePower.FullBrake;
                                case Distance.Middle:
                                    return EnginePower.Brake;
                                case Distance.Big:
                                    return EnginePower.Zero;
                                case Distance.VeryBig:
                                    return EnginePower.Throttle;
                            }
                            break;
                        
                        case Speed.Slow:
                            switch (distance)
                            {
                                case Distance.Low:
                                    return EnginePower.FullBrake;
                                case Distance.Middle:
                                    return EnginePower.Zero;
                                case Distance.Big:
                                    return EnginePower.Throttle;
                                case Distance.VeryBig:
                                    return EnginePower.Throttle;
                            }
                            break;
                        
                        case Speed.Middle:
                            switch (distance)
                            {
                                case Distance.Low:
                                    return EnginePower.Zero;
                                case Distance.Middle:
                                    return EnginePower.Throttle;
                                case Distance.Big:
                                    return EnginePower.Throttle;
                                case Distance.VeryBig:
                                    return EnginePower.FullThrottle;
                            }
                            break;
                        case Speed.Fast:
                        case Speed.VeryFast: 
                            switch (distance)
                            {
                                case Distance.Low:
                                    return EnginePower.Zero;
                                case Distance.Middle:
                                    return EnginePower.Throttle;
                                case Distance.Big:
                                    return EnginePower.FullThrottle;
                                case Distance.VeryBig:
                                    return EnginePower.FullThrottle;
                            }
                            break;
                    }
                    break;
                
                case Speed.Fast:
                case Speed.VeryFast:
                    switch (speedNextCar)
                    {
                        case (int) Speed.Stay:
                            switch (distance)
                            {
                                case Distance.Low:
                                    return EnginePower.FullBrake;
                                case Distance.Middle:
                                    return EnginePower.Brake;
                                case Distance.Big:
                                    return EnginePower.Zero;
                                case Distance.VeryBig:
                                    return EnginePower.Throttle;
                            }
                            break;
                        
                        case Speed.Slow:
                            switch (distance)
                            {
                                case Distance.Low: 
                                    return EnginePower.Brake;
                                case Distance.Middle:
                                    return EnginePower.Brake;
                                case Distance.Big:
                                    return EnginePower.Zero;
                                case Distance.VeryBig:
                                    return EnginePower.Throttle;
                            }
                            break;
                        
                        case Speed.Middle:
                            switch (distance)
                            {
                                case Distance.Low:
                                    return EnginePower.Brake;
                                case Distance.Middle:
                                    return EnginePower.Brake;
                                case Distance.Big:
                                    return EnginePower.Zero;
                                case Distance.VeryBig:
                                    return EnginePower.Throttle;
                            }
                            break;
                        case Speed.Fast:
                        case Speed.VeryFast: 
                            switch (distance)
                            {
                                case Distance.Low:
                                    return EnginePower.Brake;
                                case Distance.Middle:
                                    return EnginePower.Zero;
                                case Distance.Big:
                                    return EnginePower.FullThrottle;
                                case Distance.VeryBig:
                                    return EnginePower.FullThrottle;
                            }
                            break;
                    }
                    break;
            }

            return EnginePower.FullBrake;
        }

        // 1. Скорость автомобиля.
        // Термы: «Стоит», «Малая», «Средняя», «Высокая», «Очень высокая»
        private enum Speed
        {
            Stay = 0,
            Slow = 20,
            Middle = 50,
            Fast = 70,
            VeryFast = 100
        }

        // 2. Расстояние до впереди идущего автомобиля.
        // Термы: «Малое», «Среднее», «Большое», «Очень большое».
        private enum Distance
        {
            Low = 10,
            Middle = 50,
            Big = 100,
            VeryBig = 200
        }

        // 3. Управление одной педалью «Тормоз/Газ», от -100% до 100%.
        // Термы: «Полный тормоз» (-100%), «Полный газ» (100%), «Тормоз» (-50%), «Газ» (50%), «Ноль» (0%), 
        private enum EnginePower
        {
            FullThrottle = 100,
            Throttle = 50,
            Zero = 0,
            Brake = -50,
            FullBrake = -100
        }
    }
}