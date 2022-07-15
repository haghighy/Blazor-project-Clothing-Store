// using System.Collections.Generic;

// namespace FinalProject.Shared
// {
//     public class Cart
//     {
//         public static List<Clothe> CartClothes = new List<Clothe>();
//         public static int FinalPrice{get; set;}

//         public override string ToString() =>
//             $"{FinalPrice}";
        
//         public override int GetHashCode()
//             => FinalPrice;

//         // public override bool Equals(object obj)
//         // {
//         //     var other = obj as Cart;
//         //     if (obj is null) return false;
//         //     return FinalPrice == FinalPrice;
//         // }

//         public override bool Equals(object obj)
//         {
//             return base.Equals(obj);
//         }
//     }


// }