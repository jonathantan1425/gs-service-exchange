import Link from 'next/link';
import { useRouter } from 'next/router';
import Image from 'next/image';

export default function Navbar() {

  const router = useRouter();

  function routeToRegister(){
    router.push("/register");
  }

  function routerToLogin(){
    router.push("/login");
  }

  return (
    <nav className="flex h-20 items-center justify-between px-44 py-4 drop-shadow-md bg-grey_800">
      <div className="flex items-center justify-start">
        <Link href="/">
          <Image
            alt="GS Logo"
            src="/gs-logo-white.png"
            layout="fixed"
            height={100}
            width={100}
          />
        </Link>
      </div>

      <div className="flex justify-end items-center">
        <Link href="/about">
          <a className='text-white font-bold hover:bg-grey_600 rounded-lg py-1 w-24 text-center'>
            About
          </a>
        </Link>
        
        <Link href="/about">
          <a className='text-white font-bold hover:bg-grey_600 rounded-lg py-1 w-24 text-center'>Solutions</a>
        </Link>

        <div className="hover:bg-grey_600 rounded-lg py-1 w-24 flex justify-center">
          <svg xmlns="http://www.w3.org/2000/svg" height="24px" viewBox="0 0 24 24" width="24px" fill="#FFFFFF"><path d="M0 0h24v24H0z" fill="none"/><path d="M15.5 14h-.79l-.28-.27C15.41 12.59 16 11.11 16 9.5 16 5.91 13.09 3 9.5 3S3 5.91 3 9.5 5.91 16 9.5 16c1.61 0 3.09-.59 4.23-1.57l.27.28v.79l5 4.99L20.49 19l-4.99-5zm-6 0C7.01 14 5 11.99 5 9.5S7.01 5 9.5 5 14 7.01 14 9.5 11.99 14 9.5 14z"/></svg>
        </div>

        <a className='text-grey_600'>|</a>
        
        <Link href="/login">
          <a className='text-white font-bold hover:bg-grey_600 rounded-lg py-1 w-24 text-center'>Sign In</a>
        </Link>

      </div>
    </nav>
  );
}
