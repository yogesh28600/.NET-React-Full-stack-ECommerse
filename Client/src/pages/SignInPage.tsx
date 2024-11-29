import { signInWithEmailAndPassword } from "firebase/auth";
import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { auth } from "../Firebase/FirebaseConfig";
import { useStore } from "../stores/Store";
interface FormErrors {
  emailError?: string;
  passwordError?: string;
}
interface FormValues {
  email: string;
  password: string;
}
function validateForm(formValues: FormValues): FormErrors {
  let errors: FormErrors = {};
  if (formValues.email.length === 0) {
    errors.emailError = "Email is Required";
  }
  if (formValues.password.length < 6) {
    errors.passwordError = "Password length should be greater than 6";
  }
  return errors;
}
const SignInPage = () => {
  const { UserStore } = useStore();
  const [email, setEmail] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const [formErrors, setFormErrors] = useState<FormErrors>({
    emailError: "",
    passwordError: "",
  });
  const navigate = useNavigate();
  async function submitHandle(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();
    setFormErrors(validateForm({ email: email, password: password }));
    if (Object.keys(formErrors).length === 0) {
      try {
        const user = await signInWithEmailAndPassword(auth, email, password);
        if (user) {
          UserStore.setUser(user.user.uid);
          navigate("/");
        }
      } catch (error) {
        console.error(error);
      }
    }
  }
  return (
    <form
      onSubmit={(event) => submitHandle(event)}
      className="flex h-screen w-screen items-center justify-center gap-4 bg-[#211C24] text-white"
    >
      <div className="hidden min-h-[40%] w-[40%] flex-col items-center justify-center gap-5 md:flex">
        <h1 className="text-center text-3xl">Welcome</h1>
        <h1 className="text-center text-3xl">to</h1>
        <h1 className="text-4xl font-bold">TechTown</h1>
      </div>
      <div className="flex h-[40%] w-auto flex-col items-center gap-5 rounded-lg bg-white p-4 px-20 text-black">
        <h1 className="text-center text-2xl font-bold">Sign In</h1>
        <div>
          <input
            className="w-[20em] rounded-lg border-[1px] border-slate-300 px-4 py-2"
            name="Email"
            type="email"
            placeholder="Email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
          <p className="text-red-600">{formErrors.emailError}</p>
        </div>
        <div>
          <input
            className="w-[20em] rounded-lg border-[1px] border-slate-300 px-4 py-2"
            name="Password"
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
          <p className="text-red-600">{formErrors.passwordError}</p>
        </div>
        <button
          type="submit"
          className="rounded-lg bg-black px-4 py-2 text-white"
        >
          Sign in
        </button>
        <p>
          Not yet Registered? <Link to="/signup">Sign up</Link>
        </p>
      </div>
    </form>
  );
};

export default SignInPage;
