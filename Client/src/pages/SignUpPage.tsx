import { createUserWithEmailAndPassword } from "firebase/auth";
import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { auth } from "../Firebase/FirebaseConfig";

const SignUpPage = () => {
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const navigate = useNavigate();
  async function submitHandle(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();
    try {
      const user = await createUserWithEmailAndPassword(auth, email, password);
      console.log(user);
      navigate("/");
    } catch (error) {
      console.error(error);
    }
  }
  return (
    <form
      onSubmit={(event) => submitHandle(event)}
      className="flex h-screen w-screen items-center justify-center gap-4 bg-[#211C24] text-white"
    >
      <div className="hidden h-[40%] w-[40%] flex-col items-center justify-center gap-5 md:flex">
        <h1 className="text-center text-3xl">Welcome</h1>
        <h1 className="text-center text-3xl">to</h1>
        <h1 className="text-4xl font-bold">TechTown</h1>
      </div>
      <div className="flex h-[40%] w-auto flex-col items-center gap-5 rounded-lg bg-white p-4 px-20 text-black">
        <h1 className="text-center text-2xl font-bold">Sign Up</h1>
        <input
          className="w-[20em] rounded-lg border-[1px] border-slate-300 px-4 py-2"
          name="Email"
          type="email"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <input
          className="w-[20em] rounded-lg border-[1px] border-slate-300 px-4 py-2"
          name="Password"
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <button
          className="rounded-lg bg-black px-4 py-2 text-white"
          type="submit"
        >
          Sign up
        </button>
        <p>
          Already Registered? <Link to="/signin">Sign in</Link>
        </p>
      </div>
    </form>
  );
};

export default SignUpPage;
