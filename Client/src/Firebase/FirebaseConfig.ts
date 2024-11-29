import { initializeApp } from "firebase/app";
import { getAuth } from "firebase/auth";
// Your web app's Firebase configuration
const firebaseConfig = {
  apiKey: "AIzaSyCYglm5WRrdnp2nXfrzzbPZRdaBp5ScQYo",
  authDomain: "techtown-f5b29.firebaseapp.com",
  projectId: "techtown-f5b29",
  storageBucket: "techtown-f5b29.appspot.com",
  messagingSenderId: "517506532811",
  appId: "1:517506532811:web:28c7d01e4c48840348624e",
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
export const auth = getAuth(app);
