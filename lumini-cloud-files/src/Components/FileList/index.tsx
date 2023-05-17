import { CheckCircle, Files, XCircle } from 'phosphor-react'
import { CircularProgressbar } from 'react-circular-progressbar'
import { FileType } from '../../types/UploadedFile'
import filesIcon from '../../Assets/versions.png'

interface FileListProps {
  files: FileType[];
}

export function FileList({ files }: FileListProps) {
  return (
    <div className='mt-5 overflow-y-auto scrollbar-hide transition-all duration-500 ease-linear max-h-64'>
      { files.map(uploadedFile => (
        <li key={uploadedFile.id} className='flex justify-between items-center text-[#444] my-4'>
          <div className='flex items-center'>
            {
              uploadedFile.file.type.substring(0,5) == "image" ?
                <img src={uploadedFile.preview} className="w-9 h-9 rounded-md mr-3" /> :
                <Files size={36} weight="duotone" className='bg-back-800 text-zinc-100 rounded-md mr-3' /> 
                // <img src={filesIcon} className="w-9 h-9 rounded-md bg-no-repeat bg-cover mr-3" />
            }
            <div className='flex flex-col'>
              <h3>{uploadedFile.name.substring(0, 30)+'...'}</h3>
              <span className='text-xs text-zinc-400 mt-1'>
                {uploadedFile.readableSize}
                { uploadedFile.uploaded && <button className='bg-transparent text-red-400 ml-2 cursor-pointer'>Excluir</button> }
              </span>
            </div>
          </div>
          <div className='flex'>
            {!uploadedFile.uploaded && !uploadedFile.error && (
              <CircularProgressbar 
                value={uploadedFile.progress}
                styles={{root: { width: 24 }, path: { stroke: '#1B93B5' }}}
                strokeWidth={10}
              />
            )}

            { uploadedFile.uploaded && <CheckCircle size={24} color='#00875F' weight="fill" /> }
            { uploadedFile.error && <XCircle size={24} color='#F75A68' weight="fill" /> }
          </div>
        </li>
      )) }
    </div>
  )
}
