import Link from 'next/link';

export default function footer() {
  const footerLinks = [
    "Goldman Sachs Developer",
    "Privacy & Cookies",
    "Terms of Use",
    "Regulatory Disclosures",
    "Security",
    "Blog",
  ]

  return (
    <div className="flex h-20 items-center px-44 py-4 drop-shadow-md bg-grey_800 space-x-10">
      {footerLinks.map((link, index) => {
        return (
          <Link href="/">
            <a className='text-white font-semibold'>
              {link}
            </a>
          </Link>
        )
      })}
    </div>
  )
}