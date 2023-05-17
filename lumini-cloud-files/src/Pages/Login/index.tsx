import { SignIn } from 'phosphor-react'
import logo from '../../Assets/LuminiLogoH.png'
import illustration from '../../Assets/Upload-cuate.svg'

export function Login() {
  return (
    <div className='min-h-screen flex flex-col justify-center'>
      <div className='flex justify-center items-center mb-4'>
        <img src={logo} className='max-w-[205px]' />
      </div>

      <div className='bg-white md:mx-auto mx-4 max-w-md md:py-8 py-3 px-10 shadow rounded-lg'>
        <div className='md:mb-10 mb-5 flex justify-center'>
          <img src={illustration} className='md:h-80' />
        </div>

        <form>
          <div className='md-4'>
          <input
              type="email"
              // onChange={e => setEmail(e.target.value)}
              className="
                h-12 
                mb-2
                rounded-md 
                px-4
                py-3 
                text-zinc-900
                bg-white 
                placeholder-zinc-200 
                border-[1px] 
                border-gray-400 
                hover:border-brand-500 
                w-full 
                focus:border-brand-500 
                focus:ring-brand-500 
                focus:ring-1 
                focus:outline-none"
              placeholder="Email"
            />

          <input
              type="password"
              // onChange={e => setPassword(e.target.value)}
              className="
                h-12 
                mb-4
                rounded-md 
                px-4
                py-3  
                text-zinc-900
                bg-white 
                placeholder-zinc-200 
                border-[1px] 
                border-gray-400 
                hover:border-brand-500 
                w-full 
                focus:border-brand-500 
                focus:ring-brand-500 
                focus:ring-1 
                focus:outline-none"
              placeholder="Senha"
            />

            <button 
              type="submit" 
              className="
              bg-brand-500 
              h-12 
              rounded-md 
              font-semibold 
              text-white 
              pr-8 
              flex 
              justify-center 
              items-center 
              cursor-pointer 
              border-0
              w-full
              hover:bg-brand-400
              transition-colors
              shadow"
            >
              <SignIn /> Entrar
            </button>
          </div>
        </form>
      </div>
    </div>
  )
}
