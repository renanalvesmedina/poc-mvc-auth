import { Hexagon } from 'phosphor-react'
import logo from '../../Assets/LuminiLogoWhite.png'
import illustration from '../../Assets/Server.gif'

export function UploadAnonymous2() {
  return (
    <div className='min-h-screen flex flex-row bg-back-800'>
      <div className='min-h-screen max-w-[96px]'>
        <img src={logo} className='max-w-[80px] m-2' />
      </div>

      <div className='flex-auto flex justify-center items-center'>

        <div className='bg-white rounded-lg shadow max-w-6xl p-8 flex flex-row'>
          <div className='flex flex-col'>

            <div className='h-80'>
              <h1 className='text-lg font-extrabold'>Upload de Arquivos</h1>

              <div className='mt-4 flex flex-row'>
                <span><Hexagon size={24} weight="fill" className='text-brand-500' /></span>
                <h3 className='ml-3'>Carregar arquivos</h3>
              </div>

              <div className='mt-8 flex flex-row'>
                <span><Hexagon size={24} weight="fill" className='text-zinc-100' /></span>
                <h3 className='ml-3'>Arquivos salvos</h3>
              </div>
            </div>

            <div className='h-80 flex items-end'>
              <img src={illustration} className='w-[245px]' />
            </div>
          </div>

          <div className='w-[811px] flex flex-row'>
            <span className='bg-zinc-100 max-h-full w-[1px]'></span>
            
            <div className='w-full flex flex-col'>
              <div className='flex justify-center'>
                <h1 className='text-xl font-extrabold text-center max-w-xs'>Faça upload dos seus arquivos no campo abaixo...</h1>
              </div>

              <div className='flex flex-1 justify-center items-center'>
                <label className="flex flex-col justify-center items-center w-[513px] h-48 rounded-lg border-2 border-gray-300 border-dashed cursor-pointer hover:bg-gray-100">
                  <div className="flex flex-col justify-center items-center pt-5 pb-6">
                      <svg aria-hidden="true" className="mb-3 w-10 h-10 text-brand-500" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M7 16a4 4 0 01-.88-7.903A5 5 0 1115.9 6L16 6a5 5 0 011 9.9M15 13l-3-3m0 0l-3 3m3-3v12"></path></svg>
                      <p className="mb-2 text-sm text-brand-500">
                        <span className="font-semibold">Inserir arquivos</span>
                      </p>
                      <p className="text-xs text-gray-500 ">ou arraste aqui...</p>
                  </div>

                  <input id="dropzone-file" type="file" multiple  />
                </label>

              </div>


              <div className='flex justify-end'>
                <button 
                  className='
                  bg-brand-500 
                  rounded-full 
                  w-36 
                  h-14 
                  font-bold 
                  text-lg 
                  text-white
                  shadow
                  hover:bg-brand-400
                  transition'
                >
                  Enviar
                </button>
              </div>

            </div>

          </div>

        </div>

      </div>

    </div>
  )
}


{/* <Dropzone multiple onDropAccepted={() => {}}>
            { ({ getRootProps, getInputProps, isDragActive, isDragReject }) => (
              <DropContainer 
                { ...getRootProps() }
                isDragActive={isDragActive}
                isDragReject={isDragReject}
              >
                <input type="file" { ...getRootProps() } className=''/>
              </DropContainer>
            ) }
          </Dropzone> */}