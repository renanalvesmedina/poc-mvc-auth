import { useState } from 'react'
import fileSize from 'filesize'
import { uniqueId } from 'lodash'
import { CloudArrowUp } from 'phosphor-react'
import Dropzone from 'react-dropzone'
import { api } from '../../services/api'
import { FileList } from '../../Components/FileList'
import { FileType } from '../../types/UploadedFile'
import logo from '../../Assets/LuminiLogoWhite.png'

export function UploadAnonymous() {
  const [uploadedFiles, setUploadedFiles] = useState<FileType[]>([]);

  function handleUpload(files: any[]) {
    console.log(files);

    const uploadedFile = files.map(file => ({
      file,
      id: uniqueId(),
      name: file.name,
      readableSize: fileSize(file.size),
      preview: URL.createObjectURL(file),
      progress: 0,
      uploaded: true,
      error: false
    }));

    console.log(uploadedFile);

    setUploadedFiles(uploadedFiles.concat(uploadedFile));

    uploadedFiles.forEach(processUpload);
  }

  function updateFile(id: string, data) {
    setUploadedFiles(uploadedFiles.map(uploadedFile => {
      return id == uploadedFile.id ? { ...uploadedFile, ...data } : uploadedFile;
    }));
  }

  function processUpload(uploadedFile: FileType) {
    const data = new FormData();
    data.append('file', uploadedFile.file, uploadedFile.name);

    api.post('/upload', data, {
      onUploadProgress: e => {
        const progress = Math.round((e.loaded * 100) / e.total);

        updateFile(uploadedFile.id, { progress });
      }
    });
  }

  return (
    <div className="flex flex-col w-full h-screen justify-center items-center">
      <img src={logo} alt="" className='max-w-[160px] mt-10' />

      <div className='bg-white md:m-auto m-7 w-full max-w-md md:p-5 p-3 shadow rounded-md'>
        <div className='flex justify-center w-full'>
          <p className='text-center mb-4 text-zinc-500 font-extrabold w-72'>Faça upload dos seus arquivos no campo abaixo...</p>
        </div>
        <Dropzone multiple onDropAccepted={handleUpload}>
          { ({ getRootProps, getInputProps, isDragActive, isDragReject }) => (
            <div {...getRootProps()} className={`flex flex-row justify-center items-center p-8 border border-dashed rounded cursor-pointer transition ${isDragActive ? "border-brand-400" : isDragReject ? "border-red-400" : "border-zinc-300" }`}>
              <input { ...getInputProps() } />
                <CloudArrowUp size={18} className='text-brand-500 m-1' />
                <span className='text-brand-500 font-extrabold text-sm'>Inserir arquivos</span>
            </div>
          ) }
        </Dropzone>
        { !!uploadedFiles.length && (<FileList files={uploadedFiles} />)}
      </div>
    </div>
  )
}
