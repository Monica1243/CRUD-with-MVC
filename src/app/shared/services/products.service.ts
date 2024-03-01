import { Injectable } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  cartItems : any[] = [];
  
  constructor(private router: Router) { }
  
  Products = [
    {
      id: 1, 
      name: "Smart LED TV",
      description: "Enjoy immersive entertainment with this 4K Ultra HD Smart LED TV. Features include built-in streaming apps, HDR support, and voice control compatibility.",
      price: 699.99,
      available:true,
      discountPercentage : 2,
      imageURL: "https://5.imimg.com/data5/SELLER/Default/2023/8/333131754/ZH/ET/PH/187951374/led-tv-32-inch-frameless-smart-full-hd.png",
    },
    {
      id: 2,
      name: "Wireless Bluetooth Headphones",
      description: "These premium over-ear headphones deliver crystal-clear sound quality and all-day comfort. Features include active noise cancellation, touch controls, and 30-hour battery life.",
      price: 149.99,
      available:true,
      discountPercentage : 5.2,
      imageURL: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTzFa_g0vr76U8jD_NHDd-oxx94cXQ9zHnA7g&usqp=CAU",
    },
    {
      id: 3,
      name: "Smart Home Security Camera",
      description: "Keep your home secure with this HD smart security camera. Features include motion detection, two-way audio, and smartphone integration for remote monitoring.",
      price: 89.99,
      available:true,
      discountPercentage : 10,
      imageURL: "https://rb.gy/2sycpo",
    },
    {
      id: 4,
      name: "Electric Scooter",
      description: "Commute in style with this foldable electric scooter. With a top speed of 15 mph and a range of 15 miles, it's perfect for urban travel. Features include LED lights and a digital display.",
      price: 100800,
      available:true,
      discountPercentage : 16,
      imageURL: "https://rb.gy/47drjk",
    },
    {
      id: 5,
      name: "Portable Power Bank",
      description: "Never run out of battery with this high-capacity power bank. It's compatible with smartphones, tablets, and other USB devices. Features fast charging and multiple ports.",
      price: 999,
      available:true,
      discountPercentage : 5,
      imageURL: "https://rb.gy/qfw053",
    },
    {
      id: 6,
      name: "Air Fryer",
      description: "Cook healthier meals with this versatile air fryer. It uses hot air circulation to fry, roast, and bake your favorite foods with little to no oil. Features include a digital touchscreen and multiple presets.",
      price: 199.99,
      available:true,
      discountPercentage : 9,
      imageURL: "https://rb.gy/50frk6",
    },
    {
      id: 7,
      name: "Fitness Tracker",
      description: "Stay active and monitor your health with this advanced fitness tracker. Track steps, distance, heart rate, and sleep quality. Features a color touchscreen and smartphone notifications.",
      price: 4999,
      available:true,
      discountPercentage : 28,
      imageURL: "https://rb.gy/p9ag4u",
    },
    {
      id: 8,
      name: " Waterproof Bluetooth Speaker",
      description: "Take your music anywhere with this rugged waterproof Bluetooth speaker. Perfect for outdoor adventures, it delivers crisp sound and deep bass. Features a built-in microphone for hands-free calls.",
      price: 5999,
      available:true,
      discountPercentage : 47,
      imageURL: "https://shorturl.at/ABJY5",
    },
    {
      id: 9,
      name: "Espresso Machine",
      description: "Start your day with barista-quality coffee from this espresso machine. It features a powerful pump, milk frother, and programmable settings for customized drinks. Includes a steam wand for lattes and cappuccinos.",
      price: 19999,
      available:true,
      discountPercentage : 25,
      imageURL: "https://shorturl.at/fsvBS",
    },
    {
      id: 10,
      name: "Robot Vacuum Cleaner",
      description: "Keep your home clean effortlessly with this smart robot vacuum cleaner. It navigates through obstacles, detects dirt, and automatically adjusts suction power. Features Wi-Fi connectivity and app control.",
      price: 24999,
      available:false,
      discountPercentage : 20,
      imageURL: "https://shorturl.at/qvFN9",
    }
  ];
  

  async changeHeader(): Promise<boolean> {
    return new Promise<boolean>((resolve) => {
      let isLoginOrReg;
      this.router.events.subscribe(event => {
        if (event instanceof NavigationEnd) {
          isLoginOrReg = event.url.includes('/loginPage') || event.url.includes('/forgotPassword') || event.url.includes('/passwordPage') || event.url.includes('/RegistrationPage') || event.url.includes('/GenerateOTP')|| event.url.includes('/ChangePassword');
          resolve(isLoginOrReg);
        }
      });
    });
  }

  getAllProducts() {
    return this.Products;
  }

  addToCart(item: any) {
    this.cartItems.push(item);
  }

  removeFromCart(item: any) {
    const index = this.cartItems.indexOf(item);
    if (index !== -1) {
      this.cartItems.splice(index, 1);
    }
  }

  getCartItems() {
    return this.cartItems;
  }

}
