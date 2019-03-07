using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Characteristics:
// Z : up
// X : forward
// y : left
// Positive Yaw around the Z axis : Counter clockwise
// Negative Yaw around the z axis : Clockwise
// Front wheel max turn : 90 degrees in both directions
// Platform moves on a 2D plane
// Platform goes striaght when steering angle is 0.

//Parameers
//Front wheel radius : 0.2 m
//Back wheel radius : 0.2 m
//Distance from front wheel to back axis : (r) = 1 m
//Distance between rear wheels (d) = 0.75 m
//Traction motor on front wheel. Equipt with encoder with resolution of 512 ticks per revolution.
//Steering mechanism also includes absolute encoder which provides an estimation of steering angle.
//Platform's pose is the pose of the center of the rear axis.
//Initial pose is assumed to be (x, y, heading) = (0, 0, 0).

//At each step, teh new estimate of the position of the mobile platform is obtained through a call to an estimate method
//That method has the following API: estimate (time, steering_angle, encoder_ticks, angular_velocity) 
//returns estimated_pose(x, y, heading)



namespace Pose_Estimator
{
    class Tricycle
    {
        public double front_wheel_radius_meters { get; set; }
        public double back_wheels_radius_meters { get; set; }
        public double distance_from_front_wheel_back_axis { get; set; }
        public double distance_between_rear_wheels { get; set; }
        public int ticks_per_rev { get; set; }

        public double time { get; set; }
        public double encoder_values { get; set; }
        public double angular_velocity { get; set; }
        public double steering_angle { get; set; }

        public Tricycle(double front_wheel_radius_meters, double back_wheels_radius_meters, double distance_from_front_wheel_back_axis, double distance_between_rear_wheels, int ticks_per_rev)
        {
            this.front_wheel_radius_meters = front_wheel_radius_meters;
            this.back_wheels_radius_meters = back_wheels_radius_meters;
            this.distance_from_front_wheel_back_axis = distance_from_front_wheel_back_axis;
            this.distance_between_rear_wheels = distance_between_rear_wheels;
            this.ticks_per_rev = ticks_per_rev;
        }

        public List<int> estimate(double time, double steering_angle, double encoder_ticks, double angular_velocity)
        {
            Console.WriteLine("Current number of revolutions: {0}" , (encoder_ticks/512));

            int x = 100;
            int y = 200;
            int heading = 240;

            List<int> list = new List<int>();
            list.Add(x);
            list.Add(y);
            list.Add(heading);


            Console.WriteLine("Time: " + time);
            Console.WriteLine("Steering Angle: " + steering_angle);
            Console.WriteLine("Encoder Ticks: " + encoder_ticks);
            Console.WriteLine("Angular Velocity: " + angular_velocity);
            Console.WriteLine();
            Console.WriteLine("Estimate: x:{0}, y:{1}, heading:{2}", x, y, heading);
            
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }

            return list;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test1 = new Tricycle(0.1250, 0.1250, 0.964, 0.3673, 35136);
            test1.estimate(0.005091, 1738685, -0.003785, -0.489355);
        }
    }
}
